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
    public partial class SettingsForm : Form
    {
        public Font CurrentFont { get; set; }
        public Color CurrentColor { get; set; }
        public string HomeDir { get; private set; }

        public SettingsForm(string homeDir)
        {
            HomeDir = homeDir;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            tbHomeDir.Text = string.Join("\\", homeDir.Split('\\').Skip(1));
        }

        private void bFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.MaxSize = 35;
                fontDialog.Font = Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    CurrentFont = fontDialog.Font;
                    this.Font = CurrentFont;
                }
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (CurrentColor.ToArgb()==0)
            {
                CurrentColor = Color.White;
            }
            this.DialogResult = DialogResult.OK;
            File.WriteAllText($"{Environment.CurrentDirectory}\\Resources\\setting.txt", string.Join("\n", cbDisk.Text+tbHomeDir.Text, CurrentColor.ToArgb().ToString()));
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bBackColor_Click(object sender, EventArgs e)
        {
            
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.BackColor = colorDialog.Color;
                    CurrentColor = colorDialog.Color;
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            cbDisk.Items.AddRange(DriveInfo.GetDrives());
            cbDisk.SelectedIndex = 0;
        }
    }
}
