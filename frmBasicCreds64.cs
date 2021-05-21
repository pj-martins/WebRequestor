using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaJaMa.WebRequestor
{
    public partial class frmBasicCreds64 : Form
    {
        public frmBasicCreds64()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtOutput.Text = $"Basic " +
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{txtUsername.Text}:{txtPassword.Text}"));
        }
    }
}
