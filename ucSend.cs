using System;
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
using Newtonsoft.Json.Linq;
using ScintillaNET;

namespace PaJaMa.WebRequestor
{
	public partial class ucSend : UserControl
	{
		private BindingList<RequestResponse> _requestResponseHistory;
		public Workspace Workspace { get; set; }
		private DebounceDispatcher _removeTimer = new DebounceDispatcher();
		public string WorkspacePath { get; set; }

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
				requestResponseHistory = Workspace.RequestResponses.OrderByDescending(r => r.RequestDate).ToList() ?? new List<RequestResponse>();
				_requestResponseHistory = new BindingList<RequestResponse>(Workspace.RequestResponses.OrderByDescending(r => r.RequestDate).ToList() ?? new List<RequestResponse>());
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
				setTabText();
			}
			else
			{
				gridRequestHeaders.DataSource = new BindingList<Header>();
			}
			gridRequestsResponses.DataSource = new BindingList<RequestResponse>(requestResponseHistory);
			URL.Width = gridRequestsResponses.Width - StatusCode.Width - Method.Width - Duration.Width - 65;
			gridRequestsResponses.AutoResizeColumns();
		}

		private void setTabText()
        {
			(this.Parent as PaJaMa.WinControls.TabControl.TabPage).Text = $"{txtURL.Text.Substring(0, Math.Min(txtURL.Text.Length, 20))}{(txtURL.Text.Length > 20 ? "..." : "")}";
		}

		private async void btnGO_Click(object sender, EventArgs e)
		{
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

			populateOutputControl(reqResp);

			gridRequestsResponses.Invalidate();
			_requestResponseHistory.Insert(0, reqResp.Clone());
			Workspace.RequestResponses = _requestResponseHistory.ToList();
			File.WriteAllText(WorkspacePath, JsonConvert.SerializeObject(Workspace));

			tabRequestResponse.SelectedTab = pageResponse;
			setTabText();
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
				populateOutputControl(rr);
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
				if (string.IsNullOrEmpty(WorkspacePath)) return;
				File.WriteAllText(WorkspacePath, JsonConvert.SerializeObject(Workspace));
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

        private void btnBasic64_Click(object sender, EventArgs e)
        {
			new frmBasicCreds64().Show();
		}

		private void setFold()
        {
			txtResponse.SetProperty("fold", "1");
			txtResponse.SetProperty("fold.compact", "1");

			txtResponse.Margins[2].Type = MarginType.Symbol;
			txtResponse.Margins[2].Mask = Marker.MaskFolders;
			txtResponse.Margins[2].Sensitive = true;
			txtResponse.Margins[2].Width = 20;

			// Set colors for all folding markers
			for (int i = 25; i <= 31; i++)
			{
				txtResponse.Markers[i].SetForeColor(SystemColors.ControlLightLight);
				txtResponse.Markers[i].SetBackColor(SystemColors.ControlDark);
			}

			// Configure folding markers with respective symbols
			txtResponse.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
			txtResponse.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
			txtResponse.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
			txtResponse.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
			txtResponse.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
			txtResponse.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
			txtResponse.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

			// Enable automatic folding
			txtResponse.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
		}

		private void populateOutputControl(RequestResponse rr)
        {
			// splitResponse.Panel2.Controls.Clear();
			txtResponse.ReadOnly = false;
			txtResponse.Lexer = Lexer.Container;
			txtResponse.Text = rr.ResponseBody;
			
			try
			{
				var obj = JsonConvert.DeserializeObject(rr.ResponseBody, new JsonSerializerSettings() { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
				txtResponse.Text = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
				txtResponse.Lexer = Lexer.Json;
				txtResponse.Styles[Style.Json.Default].ForeColor = Color.Silver;
				txtResponse.Styles[Style.Json.BlockComment].ForeColor = Color.FromArgb(0, 128, 0); // Green
				txtResponse.Styles[Style.Json.LineComment].ForeColor = Color.FromArgb(0, 128, 0); // Green
				txtResponse.Styles[Style.Json.Number].ForeColor = Color.Olive;
				txtResponse.Styles[Style.Json.PropertyName].ForeColor = Color.Blue;
				txtResponse.Styles[Style.Json.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
				txtResponse.Styles[Style.Json.StringEol].BackColor = Color.Pink;
				txtResponse.Styles[Style.Json.Operator].ForeColor = Color.Purple;
				txtResponse.Colorize(0, txtResponse.Text.Length);
				setFold();
			}
			catch
			{
				txtResponse.Text = PrintXML(rr.ResponseBody);
				txtResponse.Lexer = Lexer.Xml;
				setFold();
			}
			txtResponse.ReadOnly = true;
		}

        private void Tv_DoubleClick(object sender, EventArgs e)
        {
			var tv = sender as TreeView;
			var txt = tv.SelectedNode.Text;
			var parts = txt.Split(':');
			if (parts.Length > 1)
            {
				Clipboard.SetText(string.Join(":", parts.Skip(1)).TrimStart());
            }
			else
            {
				Clipboard.SetText(txt);
            }
        }

        private void populateTreeView(TreeNodeCollection nodes, object obj, string prepend)
		{
			if (obj is JArray jarr)
            {
				var node = nodes.Add($"{(!string.IsNullOrEmpty(prepend) ? $"{prepend} : " : "")}[]");
				foreach (var el in jarr)
                {
					populateTreeView(node.Nodes, el, string.Empty);
                }
			}
			else if (obj is JObject jobj)
            {
				var node = nodes.Add($"{(!string.IsNullOrEmpty(prepend) ? $"{prepend} : " : "")}{{}}");
				foreach (var el in jobj.Children())
				{
					populateTreeView(node.Nodes, el, string.Empty);
				}
			}
			else if (obj is JProperty jprop)
            {
				if (jprop.Value is JArray || jprop.Value is JObject)
                {
					populateTreeView(nodes, jprop.Value, jprop.Name);
                }
				else
                {
                    var jval = jprop.Value as JValue;
                    string val;
                    if (jval.Value == null)
                    {
                        val = "null";
                    }
                    else
                    {
                        if (jval.Type != JTokenType.Boolean && jval.Type != JTokenType.Float && jval.Type != JTokenType.Integer)
                        {
                            val = $"\"{jval.Value}\"";
                        }
                        else
                        {
                            val = jval.Value.ToString();
                        }

						if (jval.Type == JTokenType.Boolean)
                        {
							val = val.ToLower();
                        }
                    }
                    nodes.Add($"{jprop.Name} : {val}");
				}
			}
		}
	}
}
