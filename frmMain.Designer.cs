namespace PaJaMa.WebRequestor
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.gridRequestsResponses = new System.Windows.Forms.DataGridView();
			this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabRequestResponse = new System.Windows.Forms.TabControl();
			this.pageRequest = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.gridRequestHeaders = new System.Windows.Forms.DataGridView();
			this.txtRequestBody = new System.Windows.Forms.RichTextBox();
			this.pageResponse = new System.Windows.Forms.TabPage();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.gridResponseHeaders = new System.Windows.Forms.DataGridView();
			this.txtResponseBody = new System.Windows.Forms.RichTextBox();
			this.btnGO = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.cboMethod = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRequestsResponses)).BeginInit();
			this.tabRequestResponse.SuspendLayout();
			this.pageRequest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRequestHeaders)).BeginInit();
			this.pageResponse.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridResponseHeaders)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 33);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gridRequestsResponses);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabRequestResponse);
			this.splitContainer1.Size = new System.Drawing.Size(823, 498);
			this.splitContainer1.SplitterDistance = 238;
			this.splitContainer1.TabIndex = 0;
			// 
			// gridRequestsResponses
			// 
			this.gridRequestsResponses.AllowUserToAddRows = false;
			this.gridRequestsResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridRequestsResponses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URL,
            this.Method,
            this.StatusCode});
			this.gridRequestsResponses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridRequestsResponses.Location = new System.Drawing.Point(0, 0);
			this.gridRequestsResponses.Name = "gridRequestsResponses";
			this.gridRequestsResponses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridRequestsResponses.Size = new System.Drawing.Size(238, 498);
			this.gridRequestsResponses.TabIndex = 0;
			this.gridRequestsResponses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRequestsResponses_CellDoubleClick);
			this.gridRequestsResponses.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridRequestsResponses_CellFormatting);
			this.gridRequestsResponses.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridRequestsResponses_RowsRemoved);
			// 
			// URL
			// 
			this.URL.DataPropertyName = "URL";
			this.URL.HeaderText = "URL";
			this.URL.Name = "URL";
			this.URL.ReadOnly = true;
			// 
			// Method
			// 
			this.Method.DataPropertyName = "Method";
			this.Method.HeaderText = "Method";
			this.Method.Name = "Method";
			this.Method.ReadOnly = true;
			// 
			// StatusCode
			// 
			this.StatusCode.DataPropertyName = "StatusCode";
			this.StatusCode.HeaderText = "StatusCode";
			this.StatusCode.Name = "StatusCode";
			this.StatusCode.ReadOnly = true;
			// 
			// tabRequestResponse
			// 
			this.tabRequestResponse.Controls.Add(this.pageRequest);
			this.tabRequestResponse.Controls.Add(this.pageResponse);
			this.tabRequestResponse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabRequestResponse.Location = new System.Drawing.Point(0, 0);
			this.tabRequestResponse.Name = "tabRequestResponse";
			this.tabRequestResponse.SelectedIndex = 0;
			this.tabRequestResponse.Size = new System.Drawing.Size(581, 498);
			this.tabRequestResponse.TabIndex = 1;
			// 
			// pageRequest
			// 
			this.pageRequest.Controls.Add(this.splitContainer2);
			this.pageRequest.Location = new System.Drawing.Point(4, 22);
			this.pageRequest.Name = "pageRequest";
			this.pageRequest.Padding = new System.Windows.Forms.Padding(3);
			this.pageRequest.Size = new System.Drawing.Size(573, 472);
			this.pageRequest.TabIndex = 0;
			this.pageRequest.Text = "Request";
			this.pageRequest.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.gridRequestHeaders);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.txtRequestBody);
			this.splitContainer2.Size = new System.Drawing.Size(567, 466);
			this.splitContainer2.SplitterDistance = 158;
			this.splitContainer2.TabIndex = 0;
			// 
			// gridRequestHeaders
			// 
			this.gridRequestHeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridRequestHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridRequestHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridRequestHeaders.Location = new System.Drawing.Point(0, 0);
			this.gridRequestHeaders.Name = "gridRequestHeaders";
			this.gridRequestHeaders.Size = new System.Drawing.Size(567, 158);
			this.gridRequestHeaders.TabIndex = 0;
			// 
			// txtRequestBody
			// 
			this.txtRequestBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtRequestBody.Location = new System.Drawing.Point(0, 0);
			this.txtRequestBody.Name = "txtRequestBody";
			this.txtRequestBody.Size = new System.Drawing.Size(567, 304);
			this.txtRequestBody.TabIndex = 0;
			this.txtRequestBody.Text = "";
			// 
			// pageResponse
			// 
			this.pageResponse.Controls.Add(this.splitContainer4);
			this.pageResponse.Location = new System.Drawing.Point(4, 22);
			this.pageResponse.Name = "pageResponse";
			this.pageResponse.Padding = new System.Windows.Forms.Padding(3);
			this.pageResponse.Size = new System.Drawing.Size(573, 439);
			this.pageResponse.TabIndex = 1;
			this.pageResponse.Text = "Response";
			this.pageResponse.UseVisualStyleBackColor = true;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(3, 3);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.gridResponseHeaders);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.txtResponseBody);
			this.splitContainer4.Size = new System.Drawing.Size(567, 433);
			this.splitContainer4.SplitterDistance = 147;
			this.splitContainer4.TabIndex = 1;
			// 
			// gridResponseHeaders
			// 
			this.gridResponseHeaders.AllowUserToAddRows = false;
			this.gridResponseHeaders.AllowUserToDeleteRows = false;
			this.gridResponseHeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridResponseHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridResponseHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridResponseHeaders.Location = new System.Drawing.Point(0, 0);
			this.gridResponseHeaders.Name = "gridResponseHeaders";
			this.gridResponseHeaders.Size = new System.Drawing.Size(567, 147);
			this.gridResponseHeaders.TabIndex = 0;
			// 
			// txtResponseBody
			// 
			this.txtResponseBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResponseBody.Location = new System.Drawing.Point(0, 0);
			this.txtResponseBody.Name = "txtResponseBody";
			this.txtResponseBody.Size = new System.Drawing.Size(567, 282);
			this.txtResponseBody.TabIndex = 0;
			this.txtResponseBody.Text = "";
			// 
			// btnGO
			// 
			this.btnGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGO.Location = new System.Drawing.Point(750, 5);
			this.btnGO.Name = "btnGO";
			this.btnGO.Size = new System.Drawing.Size(66, 22);
			this.btnGO.TabIndex = 0;
			this.btnGO.Text = "GO";
			this.btnGO.UseVisualStyleBackColor = true;
			this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnGO);
			this.panel2.Controls.Add(this.txtURL);
			this.panel2.Controls.Add(this.cboMethod);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(823, 33);
			this.panel2.TabIndex = 2;
			// 
			// txtURL
			// 
			this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtURL.Location = new System.Drawing.Point(139, 6);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(605, 20);
			this.txtURL.TabIndex = 1;
			// 
			// cboMethod
			// 
			this.cboMethod.FormattingEnabled = true;
			this.cboMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
			this.cboMethod.Location = new System.Drawing.Point(12, 6);
			this.cboMethod.Name = "cboMethod";
			this.cboMethod.Size = new System.Drawing.Size(121, 21);
			this.cboMethod.TabIndex = 0;
			this.cboMethod.Text = "GET";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(823, 531);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WebRequestor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRequestsResponses)).EndInit();
			this.tabRequestResponse.ResumeLayout(false);
			this.pageRequest.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRequestHeaders)).EndInit();
			this.pageResponse.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridResponseHeaders)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.DataGridView gridRequestHeaders;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.ComboBox cboMethod;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.DataGridView gridRequestsResponses;
		private System.Windows.Forms.TabControl tabRequestResponse;
		private System.Windows.Forms.TabPage pageRequest;
		private System.Windows.Forms.RichTextBox txtRequestBody;
		private System.Windows.Forms.TabPage pageResponse;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.DataGridView gridResponseHeaders;
		private System.Windows.Forms.RichTextBox txtResponseBody;
		private System.Windows.Forms.DataGridViewTextBoxColumn URL;
		private System.Windows.Forms.DataGridViewTextBoxColumn Method;
		private System.Windows.Forms.DataGridViewTextBoxColumn StatusCode;
	}
}

