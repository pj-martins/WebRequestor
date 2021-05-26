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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabSendWorkspaces = new PaJaMa.WinControls.TabControl.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ucListen1 = new PaJaMa.WebRequestor.ucListen();
            this.tabPage1 = new PaJaMa.WinControls.TabControl.TabPage();
            this.tabPage2 = new PaJaMa.WinControls.TabControl.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 636);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabSendWorkspaces);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 610);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Send";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabSendWorkspaces
            // 
            this.tabSendWorkspaces.AllowAdd = true;
            this.tabSendWorkspaces.AllowRemove = true;
            this.tabSendWorkspaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSendWorkspaces.Location = new System.Drawing.Point(3, 3);
            this.tabSendWorkspaces.MaxTextLength = 30;
            this.tabSendWorkspaces.Name = "tabSendWorkspaces";
            this.tabSendWorkspaces.SelectedTab = null;
            this.tabSendWorkspaces.Size = new System.Drawing.Size(936, 604);
            this.tabSendWorkspaces.TabIndex = 0;
            this.tabSendWorkspaces.TabClosing += new PaJaMa.WinControls.TabControl.TabEventHandler(this.tabSendWorkspaces_TabClosing);
            this.tabSendWorkspaces.TabAdding += new PaJaMa.WinControls.TabControl.TabEventHandler(this.tabSendWorkspaces_TabAdding);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucListen1);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(942, 610);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Listen";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ucListen1
            // 
            this.ucListen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucListen1.Location = new System.Drawing.Point(3, 3);
            this.ucListen1.Name = "ucListen1";
            this.ucListen1.Size = new System.Drawing.Size(936, 604);
            this.ucListen1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.IsSelected = false;
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = null;
            // 
            // tabPage2
            // 
            this.tabPage2.IsSelected = false;
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = null;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 636);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebRequestor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private WinControls.TabControl.TabPage tabPage1;
		private WinControls.TabControl.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private ucListen ucListen1;
		private WinControls.TabControl.TabControl tabSendWorkspaces;
	}
}

