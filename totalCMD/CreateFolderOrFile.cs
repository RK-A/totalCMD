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
    public partial class CreateFolderOrFile : Form
    {
        private readonly string CurrentPath;
        public CreateFolderOrFile(string path, Point startPosition)
        {
            CurrentPath = path;
            InitializeComponent();
            this.StartPosition = 0;
            this.Location = startPosition;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            CreateFolderFile();
            Close();
        }

        private void CreateFolderFile()
        {
            if (cbFolder.Checked)
            {
                try
                {
                    Directory.CreateDirectory(CurrentPath + "\\" + tbName.Text);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return;
            }
            try
            {
                using (File.Create(CurrentPath + "\\" + tbName.Text))
                {

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
