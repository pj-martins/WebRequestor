﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaJaMa.WebRequestor.Classes;
using PaJaMa.Common;
using System.Net;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using PaJaMa.WinControls;

namespace PaJaMa.WebRequestor
{
	public partial class ucSend : UserControl
	{
		private BindingList<RequestResponse> _requestResponseHistory;
		public int Index { get; set; }

		private string settingsFile => $"RequestResponseHistory_{Index}";
		private DebounceDispatcher _removeTimer = new DebounceDispatcher();

		public ucSend()
		{
			InitializeComponent();
		}

		private void ucSend_Load(object sender, EventArgs e)
		{
			gridRequestsResponses.AutoGenerateColumns = false;
			List<RequestResponse> requestResponseHistory;
			try
			{
				requestResponseHistory = SettingsHelper.GetUserSettings<List<RequestResponse>>(settingsFile).OrderByDescending(r => r.RequestDate).ToList() ?? new List<RequestResponse>();
				_requestResponseHistory = new BindingList<RequestResponse>(SettingsHelper.GetUserSettings<List<RequestResponse>>(settingsFile).OrderByDescending(r => r.RequestDate).ToList() ?? new List<RequestResponse>());
			}
			catch
			{
				requestResponseHistory = new List<RequestResponse>();
				_requestResponseHistory = new BindingList<RequestResponse>();
			}
			foreach (var rh in requestResponseHistory)
			{
				if (rh.StatusCode < 0) rh.StatusCode = 0;
			}

			if (requestResponseHistory.Any())
			{
				var first = requestResponseHistory.First();
				txtURL.Text = first.URL;
				cboMethod.Text = first.Method;
				chkUseDefaultCredentials.Checked = first.UseDefaultCredentials;
				txtRequestBody.Enabled = cboMethod.Text != "GET";
				txtRequestBody.Text = first.RequestBody;
				gridRequestHeaders.DataSource = new BindingList<Header>(first.RequestHeaders);
			}
			else
			{
				gridRequestHeaders.DataSource = new BindingList<Header>();
			}
			gridRequestsResponses.DataSource = new BindingList<RequestResponse>(requestResponseHistory);
			URL.Width = gridRequestsResponses.Width - StatusCode.Width - Method.Width - Duration.Width - 65;
			gridRequestsResponses.AutoResizeColumns();
		}

		private async void btnGO_Click(object sender, EventArgs e)
		{
			txtResponseBody.Text = string.Empty;
			gridResponseHeaders.DataSource = new BindingList<Header>();
			var reqResp = new RequestResponse();
			reqResp.URL = txtURL.Text;
			reqResp.Method = cboMethod.Text;
			if (reqResp.Method.ToLower() != "get")
			{
				reqResp.RequestBody = txtRequestBody.Text;
			}
			reqResp.RequestDate = DateTime.Now;
			reqResp.StatusCode = -1;
			reqResp.UseDefaultCredentials = chkUseDefaultCredentials.Checked;
			(gridRequestsResponses.DataSource as BindingList<RequestResponse>).Insert(0, reqResp);
			gridRequestsResponses.ClearSelection();
			gridRequestsResponses.Rows[0].Selected = true;
			HttpWebResponse response = null;
			Exception exception = null;
			DateTime? start = null;
			try
			{
				var req = WebRequest.Create(txtURL.Text) as HttpWebRequest;
				req.UserAgent = "PaJaMa WebRequestor";
				req.Accept = "*/*";
				req.KeepAlive = true;
				req.Method = cboMethod.Text;
				req.UseDefaultCredentials = chkUseDefaultCredentials.Checked;
				foreach (DataGridViewRow hdr in gridRequestHeaders.Rows)
				{
					if (hdr.DataBoundItem == null) continue;
					var header = hdr.DataBoundItem as Header;
					reqResp.RequestHeaders.Add(header);
					if (header.Name.ToLower() == "content-type")
						req.ContentType = header.Value;
					else
						req.Headers.Add(header.Name, header.Value);
				}
				start = DateTime.Now;
				if (cboMethod.Text != "GET" && !string.IsNullOrEmpty(txtRequestBody.Text))
				{
					var stream = req.GetRequestStream();
					var bytes = Common.Common.GetBytesFromString(txtRequestBody.Text);
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				response = (HttpWebResponse)await req.GetResponseAsync();
			}
			catch (WebException we)
			{
				response = (HttpWebResponse)we.Response;
				if (response == null) exception = we;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			if (start != null)
			{
				reqResp.Duration = (int)Math.Round((DateTime.Now - start.Value).TotalMilliseconds);
			}

			if (exception != null)
			{
				reqResp.StatusCode = 0;
				reqResp.ResponseBody = exception.Message;
			}
			else if (response != null)
			{
				reqResp.StatusCode = (int)response.StatusCode;
				// reqResp.Body = response.StatusDescription;
				reqResp.ResponseBody = Common.Common.GetStringFromStream(response.GetResponseStream()).Trim('\0').Trim();
				foreach (var k in response.Headers.AllKeys)
				{
					reqResp.ResponseHeaders.Add(new Header() { Name = k, Value = response.Headers[k] });
				}

				gridResponseHeaders.DataSource = reqResp.ResponseHeaders;
			}

			try
			{
				var obj = JsonConvert.DeserializeObject(reqResp.ResponseBody);
				txtResponseBody.Text = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
			}
			catch
			{
				txtResponseBody.Text = PrintXML(reqResp.ResponseBody);
			}

			gridRequestsResponses.Invalidate();
			_requestResponseHistory.Insert(0, reqResp.Clone());
			SettingsHelper.SaveUserSettings<List<RequestResponse>>(_requestResponseHistory.ToList(), settingsFile);

			tabRequestResponse.SelectedTab = pageResponse;
		}

		private string PrintXML(string xml)
		{
			string result = "";

			MemoryStream mStream = new MemoryStream();
			XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
			XmlDocument document = new XmlDocument();

			try
			{
				// Load the XmlDocument with the XML.
				document.LoadXml(xml);

				writer.Formatting = System.Xml.Formatting.Indented;

				// Write the XML into a formatting XmlTextWriter
				document.WriteContentTo(writer);
				writer.Flush();
				mStream.Flush();

				// Have to rewind the MemoryStream in order to read
				// its contents.
				mStream.Position = 0;

				// Read MemoryStream contents into a StreamReader.
				StreamReader sReader = new StreamReader(mStream);

				// Extract the text from the StreamReader.
				string formattedXml = sReader.ReadToEnd();

				result = formattedXml;
			}
			catch (XmlException)
			{
				return xml;
			}

			mStream.Close();
			writer.Close();

			return result;
		}

		private void gridRequestsResponses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				var rr = gridRequestsResponses.Rows[e.RowIndex].DataBoundItem as RequestResponse;

				txtURL.Text = rr.URL;
				cboMethod.Text = rr.Method;
				chkUseDefaultCredentials.Checked = rr.UseDefaultCredentials;
				gridRequestHeaders.DataSource = new BindingList<Header>(rr.RequestHeaders);
				gridResponseHeaders.DataSource = rr.ResponseHeaders;
				txtRequestBody.Text = rr.RequestBody;
				try
				{
					var obj = JsonConvert.DeserializeObject(rr.ResponseBody);
					txtResponseBody.Text = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
				}
				catch
				{
					txtResponseBody.Text = PrintXML(rr.ResponseBody);
				}
			}
		}

		private void gridRequestsResponses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				var rr = gridRequestsResponses.Rows[e.RowIndex].DataBoundItem as RequestResponse;
				if (rr.StatusCode < 0)
					e.CellStyle.ForeColor = Color.LightGray;
				else if (rr.StatusCode == 0)
					e.CellStyle.ForeColor = Color.Gray;
				else if (rr.StatusCode >= 400 && rr.StatusCode < 500)
					e.CellStyle.ForeColor = Color.DarkRed;
				else if (rr.StatusCode >= 500)
					e.CellStyle.ForeColor = Color.Red;
				else
					e.CellStyle.ForeColor = Color.Blue;
			}
		}

		private void gridRequestsResponses_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			_removeTimer.Debounce(100, new Action<object>((x) =>
			{
				SettingsHelper.SaveUserSettings<List<RequestResponse>>((gridRequestsResponses.DataSource as BindingList<RequestResponse>).ToList(), settingsFile);
			}));
		}

		private void cboMethod_TextChanged(object sender, EventArgs e)
		{
			txtRequestBody.Enabled = cboMethod.Text != "GET";
		}

		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			if (gridRequestsResponses.Width > URL.Width + StatusCode.Width + Method.Width + Duration.Width)
				URL.Width = gridRequestsResponses.Width - StatusCode.Width - Method.Width - Duration.Width - 65;
		}
	}
}
