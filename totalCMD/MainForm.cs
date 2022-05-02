using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace totalCMD
{
    public partial class MainForm : Form
    {
        private string currentDirectoryLeft;
        private string homeDirectory;
        private string currentDirectoryRight;
        private string oldNameLeft;
        private string oldNameRight;

        public MainForm()
        {
            InitializeComponent();
            
            homeDirectory = @"C:\Users\kiril\Downloads";
            currentDirectoryLeft = @"C:\Users\kiril\Downloads";
            // Добавляет файлы домшней директории в левую часть
            GoPathLeft(homeDirectory);
            tbPathLeft.Text = currentDirectoryLeft;
            
        }
        private List<object[]> GetObjectsInFolder(string path, ref string currentDirectory)
        {
            var answer = new List<object[]>();
            string oldPath = currentDirectory;
            if (Directory.Exists(path))
            {
                try
                {
                    var dirInfo = new DirectoryInfo(path);
                    currentDirectory = string.Join("\\", dirInfo.FullName.Split('\\').Skip(1));
                    if (dirInfo.FullName.Replace(path.Split('\\')[0] + "\\", "") != string.Empty)
                    {
                        answer.Add(new object[] { $"[..]", "<DIR>", "<DIR>", dirInfo.Parent.CreationTime.ToString() });
                    }
                    foreach (var directory in dirInfo.GetDirectories())
                    {
                        answer.Add(new object[] { $"[{directory.Name}]", "<DIR>", "<DIR>", directory.CreationTime.ToString() });

                    }
                    foreach (var file in dirInfo.GetFiles())
                    {
                        answer.Add(new object[] { file.Name, file.Extension, file.Length.ToString("#,#"), file.CreationTime.ToString() });
                    }
                    string[] files = Directory.GetFiles(path);
                    return answer;
                }
                catch (Exception excep)
                {
                    currentDirectory = oldPath;
                    MessageBox.Show(excep.Message);
                }
                
            }
            return null;
        }

        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            dgViewLeft.Width = splitContainer.Panel1.Width;
        }

        private void splitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
            dgViewRight.Width = splitContainer.Panel2.Width - panelTools.Width;
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            cbLeft.Items.AddRange(DriveInfo.GetDrives());
            cbLeft.SelectedIndex = 0;

            cbRight.Items.AddRange(DriveInfo.GetDrives());
            cbRight.SelectedIndex = 0;
            panelTools.Width = cbRight.Width;
            this.Width += 1;
        }
        /// <summary>
        /// Метод удалющий дериктории
        /// </summary>
        /// <param name="path"></param>
        private void DeleteDir(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                DeleteDir(dir.FullName);
            }
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            Directory.Delete(path);
        }


        #region LeftGridView
        //Обновить таблицу по пути
        private void GoPathLeft(string path)
        {
            List<object[]> data = GetObjectsInFolder(path, ref currentDirectoryLeft);
            if (data == null)
            {
                tbPathLeft.Text = currentDirectoryLeft;
                return;
            }
            dgViewLeft.Rows.Clear();
            tbPathLeft.Text = currentDirectoryLeft;
            foreach (var item in data)
            {
                dgViewLeft.Rows.Add(item);
            }
        }
        // Изменяется текст значение текст 
        private void tbPathLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoPathLeft(cbLeft.Text + tbPathLeft.Text);
                return;
            }
        }
        // Выбор диска
        private void cbLeft_TextChanged(object sender, EventArgs e)
        {
            if ((cbLeft.Text + currentDirectoryLeft).Equals(homeDirectory))
            {
                return;
            }
            GoPathLeft(cbLeft.Text);
        }
        /// <summary>
        /// Двойной клик по ячейкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewLeft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count == 1 && e.RowIndex != -1)
            {
                if (CheckIsFolderLeft(e.RowIndex))
                {
                    string newPath = cbLeft.Text + currentDirectoryLeft + "\\" + dgViewLeft.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("[", "").Replace("]", "");
                    GoPathLeft(newPath);
                    return;
                }
                string pathExecute = cbLeft.Text + currentDirectoryLeft + "\\" + dgViewLeft.Rows[e.RowIndex].Cells[0].Value.ToString();
                try
                {
                    Process.Start(pathExecute);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }
        /// <summary>
        /// Создать в контекстном меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createToolStripLeft_Click(object sender, EventArgs e)
        {

            using (var form = new CreateFolderOrFile(cbLeft.Text + currentDirectoryLeft))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GoPathLeft(cbLeft.Text + currentDirectoryLeft);
                }
            }
        }
        /// <summary>
        /// Удалить из таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripLeft_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                foreach (DataGridViewRow row in dgViewLeft.SelectedRows)
                {
                    if (CheckIsFolderLeft(row.Index))
                    {
                        DeleteDir(cbLeft.Text + currentDirectoryLeft + "\\" + row.Cells[0].Value);
                    }
                    else
                    {
                        File.Delete(cbLeft.Text + currentDirectoryLeft + "\\" + row.Cells[0].Value);
                    }

                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            GoPathLeft(cbLeft.Text + currentDirectoryLeft);
        }
        /// <summary>
        /// Метод вызывающий контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewLeft_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.Button != MouseButtons.Right)
            {
                return;
            }
            MenuStripLeft.Show(MousePosition.X, MousePosition.Y);
            if (!dgViewLeft.SelectedRows.Contains(dgViewLeft.Rows[e.RowIndex]))
            {
                dgViewLeft.CurrentCell = dgViewLeft.Rows[e.RowIndex].Cells[0];
            }

        }
        /// <summary>
        /// Переименовать в контекстном меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameToolStripLeft_Click(object sender, EventArgs e)
        {
            dgViewLeft.BeginEdit(true);
        }
        /// <summary>
        /// Перед редактированием ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewLeft_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int index = e.RowIndex;
            if (CheckIsFolderLeft(index))
            {
                oldNameLeft = dgViewLeft.Rows[index].Cells[0].Value.ToString().Replace("[", "").Replace("]", "");
                dgViewLeft.Rows[index].Cells[0].Value = oldNameLeft;
            }
            oldNameLeft = dgViewLeft.Rows[index].Cells[0].Value.ToString();
        }
        /// <summary>
        /// После редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewLeft_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewLeft.IsCurrentRowDirty && oldNameLeft != null)
            {
                int index = e.RowIndex;
                string newName = dgViewLeft.Rows[index].Cells[0].Value.ToString();
                string oldPath = cbLeft.Text + currentDirectoryLeft + "\\" + oldNameLeft;
                string newPath = cbLeft.Text + currentDirectoryLeft + "\\" + newName;
                try
                {
                    if (CheckIsFolderLeft(index))
                    {
                        Directory.Move(oldPath, newPath);
                        dgViewLeft.Rows[index].Cells[0].Value = $"[{newName}]";
                        GoPathLeft(cbLeft + currentDirectoryLeft);
                        return;
                    }
                    File.Move(oldPath, newPath);
                    GoPathLeft(cbLeft + currentDirectoryLeft);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    if (CheckIsFolderLeft(index))
                    {
                        dgViewLeft.Rows[index].Cells[0].Value = $"[{oldNameLeft}]";
                        return;
                    }

                    dgViewLeft.Rows[index].Cells[0].Value = oldNameLeft;

                }
            }
        }
        /// <summary>
        /// Проверка на папку
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool CheckIsFolderLeft(int index)
        {
            return dgViewLeft.Rows[index].Cells[1].Value.Equals("<DIR>");
        }
        #endregion

        #region RightGridView
        private void GoPathRight(string path)
        {
            List<object[]> data = GetObjectsInFolder(path, ref currentDirectoryRight);
            if (data == null)
            {
                tbPathRight.Text = currentDirectoryRight;
                return;
            }
            dgViewRight.Rows.Clear();
            tbPathRight.Text = currentDirectoryRight;
            foreach (var item in data)
            {
                dgViewRight.Rows.Add(item);
            }
        }
        
        private void cbRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            GoPathRight(cbRight.Text);
        }

        private void tbPathRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoPathRight(cbRight.Text + tbPathRight.Text);
                return;
            }
        }

        private void dgViewRight_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewRight.SelectedRows.Count == 1 && e.RowIndex != -1)
            {
                if (CheckIsFolderRight(e.RowIndex))
                {
                    string newPath = cbRight.Text + currentDirectoryRight + "\\" + dgViewRight.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("[", "").Replace("]", "");
                    GoPathRight(newPath);
                    return;
                }
                string pathExecute = cbRight.Text + currentDirectoryRight + "\\" + dgViewRight.Rows[e.RowIndex].Cells[0].Value.ToString();
                try
                {
                    Process.Start(pathExecute);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }
        
        private bool CheckIsFolderRight(int index)
        {
            return dgViewRight.Rows[index].Cells[1].Value.Equals("<DIR>");
        }

        private void dgViewRight_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.Button != MouseButtons.Right)
            {
                return;
            }
            MenuStripRight.Show(MousePosition.X, MousePosition.Y);
            if (!dgViewRight.SelectedRows.Contains(dgViewRight.Rows[e.RowIndex]))
            {
                dgViewRight.CurrentCell = dgViewRight.Rows[e.RowIndex].Cells[0];
            }
        }

        private void dgViewRight_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int index = e.RowIndex;
            if (CheckIsFolderRight(index))
            {
                oldNameRight = dgViewRight.Rows[index].Cells[0].Value.ToString().Replace("[", "").Replace("]", "");
                dgViewRight.Rows[index].Cells[0].Value = oldNameRight;
            }
            oldNameRight = dgViewRight.Rows[index].Cells[0].Value.ToString();
        }

        private void dgViewRight_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewRight.IsCurrentRowDirty && oldNameRight != null)
            {
                int index = e.RowIndex;
                string newName = dgViewRight.Rows[index].Cells[0].Value.ToString();
                string oldPath = cbRight.Text + currentDirectoryRight + "\\" + oldNameRight;
                string newPath = cbRight.Text + currentDirectoryRight + "\\" + newName;
                try
                {
                    if (CheckIsFolderRight(index))
                    {
                        Directory.Move(oldPath, newPath);
                        dgViewRight.Rows[index].Cells[0].Value = $"[{newName}]";
                        GoPathRight(cbRight + currentDirectoryRight);
                        return;
                    }
                    File.Move(oldPath, newPath);
                    GoPathRight(cbRight + currentDirectoryRight);
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    if (CheckIsFolderRight(index))
                    {
                        dgViewRight.Rows[index].Cells[0].Value = $"[{oldNameRight}]";
                        return;
                    }

                    dgViewRight.Rows[index].Cells[0].Value = oldNameRight;

                }
            }
        }

        private void createToolStripRight_Click(object sender, EventArgs e)
        {
            using (var form = new CreateFolderOrFile(cbRight.Text + currentDirectoryRight))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GoPathRight(cbRight.Text + currentDirectoryRight);
                }
            }
        }

        private void deleteToolStripRight_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                foreach (DataGridViewRow row in dgViewRight.SelectedRows)
                {
                    if (CheckIsFolderRight(row.Index))
                    {
                        DeleteDir(cbRight.Text + currentDirectoryRight + "\\" + row.Cells[0].Value);
                    }
                    else
                    {
                        File.Delete(cbRight.Text + currentDirectoryRight + "\\" + row.Cells[0].Value);
                    }

                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            GoPathRight(cbRight.Text + currentDirectoryRight);
        }

        private void renameToolStripRight_Click(object sender, EventArgs e)
        {
            dgViewRight.BeginEdit(true);
        }

        #endregion

        private void copyToolStripLeft_Click(object sender, EventArgs e)
        {

        }

        private void dgViewLeft_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewRight.SelectedRows.Count>0)
            {
                dgViewRight.ClearSelection();
            }
        }

        private void dgViewRight_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count>0)
            {
                dgViewLeft.ClearSelection();
            }
        }
    }
}
