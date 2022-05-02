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
    public partial class FileInfoForm : Form
    {
        
        public FileInfoForm(FileInfo fileInfo)
        {
            InitializeComponent();
            tbName.Text = "Name: " + fileInfo.Name;
            tbLength.Text = "Size: " + fileInfo.Length;
            tbCreationTime.Text = "Creation time: " + fileInfo.CreationTime.ToString("f");
            tbLastWritetime.Text = "Last time edit: " + fileInfo.LastWriteTime.ToString("f");
            tbDirectionName.Text = "Path: " + fileInfo.DirectoryName;
        }
        public FileInfoForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            tbName.Text = "Name: " + dirInfo.Name;
            tbCreationTime.Text = "Creation time: " + dirInfo.CreationTime.ToString("f");
            tbLastWritetime.Text = "Last time edit: " + dirInfo.LastWriteTime.ToString("f");
            tbDirectionName.Text = "Path: " + dirInfo.FullName;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
