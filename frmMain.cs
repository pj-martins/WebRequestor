using Newtonsoft.Json;
using PaJaMa.Common;
using PaJaMa.WebRequestor.Classes;
using PaJaMa.WinControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PaJaMa.WebRequestor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private string workspaceDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Assembly.GetEntryAssembly().AssemblyTitle());

        private void frmMain_Load(object sender, EventArgs e)
        {
            FormSettings.LoadSettings(this);

			var dinf = new DirectoryInfo(workspaceDirectory);
			if (!dinf.Exists) dinf.Create();
			var files = dinf.GetFiles().Where(x => x.FullName.Contains("Workspace_")).OrderBy(c => c.CreationTime);
            foreach (var file in files)
            {
                try
                {
                    var deserialized = JsonConvert.DeserializeObject<Workspace>(File.ReadAllText(file.FullName));
                    addSendWorkspace(deserialized);
                }
                catch
                {
                    // invalid json
                }
            }

            if (tabSendWorkspaces.TabPages.Count < 1)
                addSendWorkspace(null);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            FormSettings.SaveSettings(this);
        }

        private ucSend addSendWorkspace(Workspace workspace)
        {
            if (workspace == null)
            {
                workspace = new Workspace();
            }
            var uc = new ucSend();
            uc.Workspace = workspace;
            uc.WorkspacePath = Path.Combine(workspaceDirectory, $"Workspace_{workspace.ID}");
            var tabPage = new WinControls.TabControl.TabPage();
            tabPage.Text = "Workspace " + (tabSendWorkspaces.TabPages.Count + 1).ToString();
            tabPage.ContextMenuStrip = new ContextMenuStrip();
            tabPage.ContextMenuStrip.Items.Add("&Copy To Workspace", null, new EventHandler(this.copyToWorkspaceToolStripMenuItem_Click));
            uc.Dock = DockStyle.Fill;
            tabPage.Controls.Add(uc);
            tabSendWorkspaces.TabPages.Add(tabPage);
            tabSendWorkspaces.SelectedTab = tabPage;
            return uc;
        }

        private void tabSendWorkspaces_TabAdding(object sender, WinControls.TabControl.TabEventArgs e)
        {
            addSendWorkspace(null);
            e.Cancel = true;
        }

        private void tabSendWorkspaces_TabClosing(object sender, WinControls.TabControl.TabEventArgs e)
        {
            var uc = e.TabPage.Controls[0] as ucSend;
            Directory.Delete(uc.WorkspacePath, true);
            File.Delete(uc.WorkspacePath + ".json");
            uc.WorkspacePath = string.Empty;
        }

        private void copyToWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Workspace workspace = null;
            var selectedTab = tabSendWorkspaces.SelectedTab;
            if (selectedTab != null)
            {
                workspace = new Workspace()
                {
                    ID = Guid.NewGuid(),
                    RequestResponses = (selectedTab.Controls[0] as ucSend).Workspace.RequestResponses.OrderByDescending(x => x.RequestDate).Take(1).ToList()
                };
            }
            addSendWorkspace(workspace);
        }
    }
}
