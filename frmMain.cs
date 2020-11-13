using PaJaMa.WebRequestor.Classes;
using PaJaMa.WinControls;
using System;
using System.Windows.Forms;

namespace PaJaMa.WebRequestor
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			FormSettings.LoadSettings(this);

			var sendSettings = PaJaMa.Common.SettingsHelper.GetUserSettings<SendWorkspaces>();
			for (int i = 0; i < sendSettings.TabCount; i++)
			{
				addSendWorkspace(null);
			}

			if (tabSendWorkspaces.TabPages.Count < 1)
				addSendWorkspace(null);
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized) return;

			FormSettings.SaveSettings(this);
		}

		private ucSend addSendWorkspace(WinControls.TabControl.TabPage tabPage)
		{
			var uc = new ucSend();
			uc.Index = tabSendWorkspaces.TabPages.Count;
			bool add = false;
			if (tabPage == null)
			{
				tabPage = new WinControls.TabControl.TabPage();
				add = true;
			}
			tabPage.Text = "Workspace " + (uc.Index + 1).ToString();
			uc.Dock = DockStyle.Fill;
			tabPage.Controls.Add(uc);
			if (add)
			{
				tabSendWorkspaces.TabPages.Add(tabPage);
				tabSendWorkspaces.SelectedTab = tabPage;
			}
			return uc;
		}

		private void tabSendWorkspaces_TabAdding(object sender, WinControls.TabControl.TabEventArgs e)
		{
			addSendWorkspace(e.TabPage);
		}
	}
}
