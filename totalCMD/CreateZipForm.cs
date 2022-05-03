using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace totalCMD
{
    public partial class CreateZipForm : Form
    {
        private string CurrentPath { get; set; }
        public string FilePath { get; private set; }
        public CreateZipForm(string path)
        {
            CurrentPath = path;
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (File.Exists(CurrentPath+"\\"+tbName.Text+".zip"))
            {
                lRename.Visible = true;
                return;
            }
            FilePath = CurrentPath + "\\" + tbName.Text + ".zip";
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
