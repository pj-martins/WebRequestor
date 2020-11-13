namespace PaJaMa.WebRequestor
{
	partial class ucListen
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
			this.gridResponses = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.numPort = new System.Windows.Forms.NumericUpDown();
			this.btnGO = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridResponses)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
			this.SuspendLayout();
			// 
			// gridResponses
			// 
			this.gridResponses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridResponses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridResponses.Location = new System.Drawing.Point(0, 33);
			this.gridResponses.Name = "gridResponses";
			this.gridResponses.Size = new System.Drawing.Size(995, 747);
			this.gridResponses.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.numPort);
			this.panel2.Controls.Add(this.btnGO);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(995, 33);
			this.panel2.TabIndex = 6;
			// 
			// numPort
			// 
			this.numPort.Location = new System.Drawing.Point(47, 7);
			this.numPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numPort.Name = "numPort";
			this.numPort.Size = new System.Drawing.Size(120, 20);
			this.numPort.TabIndex = 1;
			// 
			// btnGO
			// 
			this.btnGO.Location = new System.Drawing.Point(173, 5);
			this.btnGO.Name = "btnGO";
			this.btnGO.Size = new System.Drawing.Size(66, 22);
			this.btnGO.TabIndex = 0;
			this.btnGO.Text = "Start";
			this.btnGO.UseVisualStyleBackColor = true;
			this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Port";
			// 
			// ucListen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridResponses);
			this.Controls.Add(this.panel2);
			this.Name = "ucListen";
			this.Size = new System.Drawing.Size(995, 780);
			((System.ComponentModel.ISupportInitialize)(this.gridResponses)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridResponses;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnGO;
		private System.Windows.Forms.NumericUpDown numPort;
		private System.Windows.Forms.Label label1;
	}
}
