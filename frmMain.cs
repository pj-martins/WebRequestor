using Newtonsoft.Json;
using PaJaMa.Common;
using PaJaMa.WebRequestor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaJaMa.WebRequestor
{
	public partial class frmMain : Form
	{
		const string REQUEST_RESPONSE_HISTORY = "RequestResponseHistory";

		private BindingList<RequestResponse> _requestResponseHistory;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			FormSettings.LoadSettings(this);
			gridRequestsResponses.AutoGenerateColumns = false;
			var requestResponseHistory = SettingsHelper.GetUserSettings<List<RequestResponse>>(REQUEST_RESPONSE_HISTORY).OrderByDescending(r => r.RequestDate).ToList() ?? new List<RequestResponse>();
			foreach (var rh in requestResponseHistory)
			{
				if (rh.StatusCode < 0) rh.StatusCode = 0;
			}
			if (requestResponseHistory.Any())
			{
				var first = requestResponseHistory.First();
				txtURL.Text = first.URL;
				cboMethod.Text = first.Method;
				txtRequestBody.Text = first.RequestBody;
				gridRequestHeaders.DataSource = new BindingList<Header>(first.RequestHeaders);
			}
			else
			{
				gridRequestHeaders.DataSource = new BindingList<Header>();
			}
			gridRequestsResponses.DataSource = _requestResponseHistory = new BindingList<RequestResponse>(requestResponseHistory);
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized) return;

			FormSettings.SaveSettings(this);
		}

		private async void btnGO_Click(object sender, EventArgs e)
		{
			var reqResp = new RequestResponse();
			reqResp.URL = txtURL.Text;
			reqResp.RequestBody = txtRequestBody.Text;
			reqResp.Method = cboMethod.Text;
			reqResp.RequestDate = DateTime.Now;
			reqResp.StatusCode = -1;
			_requestResponseHistory.Insert(0, reqResp);
			HttpWebResponse response = null;
			try
			{
				var req = WebRequest.Create(txtURL.Text);
				req.Method = cboMethod.Text;
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
				if (!string.IsNullOrEmpty(txtRequestBody.Text))
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			if (response == null) return;

			reqResp.StatusCode = (int)response.StatusCode;
			// reqResp.Body = response.StatusDescription;
			reqResp.ResponseBody = Common.Common.GetStringFromStream(response.GetResponseStream()).Trim('\0').Trim();
			foreach (var k in response.Headers.AllKeys)
			{
				reqResp.ResponseHeaders.Add(new Header() { Name = k, Value = response.Headers[k] });
			}

			gridResponseHeaders.DataSource = reqResp.ResponseHeaders;
			try
			{
				var obj = JsonConvert.DeserializeObject(reqResp.ResponseBody);
				txtResponseBody.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
			}
			catch
			{
				txtResponseBody.Text = reqResp.ResponseBody;
			}

			gridRequestsResponses.Invalidate();
			SettingsHelper.SaveUserSettings<List<RequestResponse>>(_requestResponseHistory.ToList(), REQUEST_RESPONSE_HISTORY);

			tabRequestResponse.SelectedTab = pageResponse;
		}

		private void gridRequestsResponses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				var rr = gridRequestsResponses.Rows[e.RowIndex].DataBoundItem as RequestResponse;

				txtURL.Text = rr.URL;
				cboMethod.Text = rr.Method;
				gridRequestHeaders.DataSource = new BindingList<Header>(rr.RequestHeaders);
				gridResponseHeaders.DataSource = rr.ResponseHeaders;
				txtRequestBody.Text = rr.RequestBody;
				try
				{
					var obj = JsonConvert.DeserializeObject(rr.ResponseBody);
					txtResponseBody.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
				}
				catch
				{
					txtResponseBody.Text = rr.ResponseBody;
				}
			}
		}

		private void gridRequestsResponses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				var rr = gridRequestsResponses.Rows[e.RowIndex].DataBoundItem as RequestResponse;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				if (rr.StatusCode == 0)
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
			SettingsHelper.SaveUserSettings<List<RequestResponse>>(_requestResponseHistory.ToList(), REQUEST_RESPONSE_HISTORY);
		}
	}
}
