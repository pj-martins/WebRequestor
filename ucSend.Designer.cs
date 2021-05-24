namespace PaJaMa.WebRequestor
{
	partial class ucSend
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.cboMethod = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGO = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.gridResponseHeaders = new System.Windows.Forms.DataGridView();
            this.splitResponse = new System.Windows.Forms.SplitContainer();
            this.txtResponse = new ScintillaNET.Scintilla();
            this.pageResponse = new System.Windows.Forms.TabPage();
            this.txtRequestBody = new ScintillaNET.Scintilla();
            this.chkUseDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.gridRequestHeaders = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBasic64 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pageRequest = new System.Windows.Forms.TabPage();
            this.tabRequestResponse = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridRequestsResponses = new System.Windows.Forms.DataGridView();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponseLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progMain = new System.Windows.Forms.ProgressBar();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResponseHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitResponse)).BeginInit();
            this.splitResponse.Panel1.SuspendLayout();
            this.splitResponse.Panel2.SuspendLayout();
            this.splitResponse.SuspendLayout();
            this.pageResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRequestHeaders)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pageRequest.SuspendLayout();
            this.tabRequestResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRequestsResponses)).BeginInit();
            this.SuspendLayout();
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
            this.cboMethod.TextChanged += new System.EventHandler(this.cboMethod_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGO);
            this.panel2.Controls.Add(this.txtURL);
            this.panel2.Controls.Add(this.cboMethod);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 33);
            this.panel2.TabIndex = 4;
            // 
            // btnGO
            // 
            this.btnGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGO.Location = new System.Drawing.Point(958, 5);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(66, 22);
            this.btnGO.TabIndex = 0;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(139, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(813, 20);
            this.txtURL.TabIndex = 1;
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
            this.gridResponseHeaders.Size = new System.Drawing.Size(567, 216);
            this.gridResponseHeaders.TabIndex = 0;
            // 
            // splitResponse
            // 
            this.splitResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitResponse.Location = new System.Drawing.Point(3, 3);
            this.splitResponse.Name = "splitResponse";
            this.splitResponse.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitResponse.Panel1
            // 
            this.splitResponse.Panel1.Controls.Add(this.gridResponseHeaders);
            // 
            // splitResponse.Panel2
            // 
            this.splitResponse.Panel2.Controls.Add(this.txtResponse);
            this.splitResponse.Size = new System.Drawing.Size(567, 642);
            this.splitResponse.SplitterDistance = 216;
            this.splitResponse.TabIndex = 1;
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(0, 0);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(567, 422);
            this.txtResponse.TabIndex = 0;
            this.txtResponse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponse_KeyDown);
            // 
            // pageResponse
            // 
            this.pageResponse.Controls.Add(this.splitResponse);
            this.pageResponse.Location = new System.Drawing.Point(4, 22);
            this.pageResponse.Name = "pageResponse";
            this.pageResponse.Padding = new System.Windows.Forms.Padding(3);
            this.pageResponse.Size = new System.Drawing.Size(573, 648);
            this.pageResponse.TabIndex = 1;
            this.pageResponse.Text = "Response";
            this.pageResponse.UseVisualStyleBackColor = true;
            // 
            // txtRequestBody
            // 
            this.txtRequestBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequestBody.Location = new System.Drawing.Point(0, 0);
            this.txtRequestBody.Name = "txtRequestBody";
            this.txtRequestBody.Size = new System.Drawing.Size(567, 422);
            this.txtRequestBody.TabIndex = 0;
            // 
            // chkUseDefaultCredentials
            // 
            this.chkUseDefaultCredentials.AutoSize = true;
            this.chkUseDefaultCredentials.Location = new System.Drawing.Point(3, 10);
            this.chkUseDefaultCredentials.Name = "chkUseDefaultCredentials";
            this.chkUseDefaultCredentials.Size = new System.Drawing.Size(137, 17);
            this.chkUseDefaultCredentials.TabIndex = 1;
            this.chkUseDefaultCredentials.Text = "Use Default Credentials";
            this.chkUseDefaultCredentials.UseVisualStyleBackColor = true;
            // 
            // gridRequestHeaders
            // 
            this.gridRequestHeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridRequestHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRequestHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRequestHeaders.Location = new System.Drawing.Point(0, 0);
            this.gridRequestHeaders.Name = "gridRequestHeaders";
            this.gridRequestHeaders.Size = new System.Drawing.Size(567, 216);
            this.gridRequestHeaders.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBasic64);
            this.panel1.Controls.Add(this.chkUseDefaultCredentials);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 32);
            this.panel1.TabIndex = 2;
            // 
            // btnBasic64
            // 
            this.btnBasic64.Location = new System.Drawing.Point(146, 6);
            this.btnBasic64.Name = "btnBasic64";
            this.btnBasic64.Size = new System.Drawing.Size(88, 23);
            this.btnBasic64.TabIndex = 2;
            this.btnBasic64.Text = "Basic 64";
            this.btnBasic64.UseVisualStyleBackColor = true;
            this.btnBasic64.Click += new System.EventHandler(this.btnBasic64_Click);
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
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.gridRequestHeaders);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtRequestBody);
            this.splitContainer2.Size = new System.Drawing.Size(567, 642);
            this.splitContainer2.SplitterDistance = 216;
            this.splitContainer2.TabIndex = 0;
            // 
            // pageRequest
            // 
            this.pageRequest.Controls.Add(this.splitContainer2);
            this.pageRequest.Location = new System.Drawing.Point(4, 22);
            this.pageRequest.Name = "pageRequest";
            this.pageRequest.Padding = new System.Windows.Forms.Padding(3);
            this.pageRequest.Size = new System.Drawing.Size(573, 648);
            this.pageRequest.TabIndex = 0;
            this.pageRequest.Text = "Request";
            this.pageRequest.UseVisualStyleBackColor = true;
            // 
            // tabRequestResponse
            // 
            this.tabRequestResponse.Controls.Add(this.pageRequest);
            this.tabRequestResponse.Controls.Add(this.pageResponse);
            this.tabRequestResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRequestResponse.Location = new System.Drawing.Point(0, 0);
            this.tabRequestResponse.Name = "tabRequestResponse";
            this.tabRequestResponse.SelectedIndex = 0;
            this.tabRequestResponse.Size = new System.Drawing.Size(581, 674);
            this.tabRequestResponse.TabIndex = 1;
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
            this.splitContainer1.Panel1.Controls.Add(this.progMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabRequestResponse);
            this.splitContainer1.Size = new System.Drawing.Size(1031, 674);
            this.splitContainer1.SplitterDistance = 446;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // gridRequestsResponses
            // 
            this.gridRequestsResponses.AllowUserToAddRows = false;
            this.gridRequestsResponses.AllowUserToOrderColumns = true;
            this.gridRequestsResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRequestsResponses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URL,
            this.Method,
            this.StatusCode,
            this.Duration,
            this.RequestDate,
            this.ResponseLength});
            this.gridRequestsResponses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRequestsResponses.Location = new System.Drawing.Point(0, 0);
            this.gridRequestsResponses.Name = "gridRequestsResponses";
            this.gridRequestsResponses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRequestsResponses.Size = new System.Drawing.Size(446, 651);
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
            this.StatusCode.Width = 80;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 50;
            // 
            // RequestDate
            // 
            this.RequestDate.DataPropertyName = "RequestDate";
            this.RequestDate.HeaderText = "Date";
            this.RequestDate.Name = "RequestDate";
            // 
            // ResponseLength
            // 
            this.ResponseLength.DataPropertyName = "ResponseLength";
            this.ResponseLength.HeaderText = "Length";
            this.ResponseLength.Name = "ResponseLength";
            // 
            // progMain
            // 
            this.progMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progMain.Location = new System.Drawing.Point(0, 651);
            this.progMain.Name = "progMain";
            this.progMain.Size = new System.Drawing.Size(446, 23);
            this.progMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progMain.TabIndex = 2;
            // 
            // ucSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "ucSend";
            this.Size = new System.Drawing.Size(1031, 707);
            this.Load += new System.EventHandler(this.ucSend_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResponseHeaders)).EndInit();
            this.splitResponse.Panel1.ResumeLayout(false);
            this.splitResponse.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitResponse)).EndInit();
            this.splitResponse.ResumeLayout(false);
            this.pageResponse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRequestHeaders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pageRequest.ResumeLayout(false);
            this.tabRequestResponse.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRequestsResponses)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboMethod;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.DataGridView gridResponseHeaders;
		private System.Windows.Forms.SplitContainer splitResponse;
		private System.Windows.Forms.TabPage pageResponse;
		private ScintillaNET.Scintilla txtRequestBody;
		private System.Windows.Forms.CheckBox chkUseDefaultCredentials;
		private System.Windows.Forms.DataGridView gridRequestHeaders;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TabPage pageRequest;
		private System.Windows.Forms.TabControl tabRequestResponse;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView gridRequestsResponses;
		private System.Windows.Forms.DataGridViewTextBoxColumn URL;
		private System.Windows.Forms.DataGridViewTextBoxColumn Method;
		private System.Windows.Forms.DataGridViewTextBoxColumn StatusCode;
		private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
		private System.Windows.Forms.DataGridViewTextBoxColumn RequestDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn ResponseLength;
        private System.Windows.Forms.Button btnBasic64;
        private ScintillaNET.Scintilla txtResponse;
        private System.Windows.Forms.ProgressBar progMain;
    }
}
