using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
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

        public Color CurrentColor { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            SetSettings();
            // Добавляет файлы домшней директории в левую часть
            GoPathLeft(homeDirectory);
            currentDirectoryLeft = string.Join("\\", homeDirectory.Split('\\').Skip(1));
            tbPathLeft.Text = currentDirectoryLeft;
            this.panelTools.BackColor = CurrentColor;
        }

        private void SetSettings()
        {
            string path = $"{Environment.CurrentDirectory}\\Resources\\setting.txt";
            if (!File.Exists(path))
            {
                homeDirectory = "";
                return;
            }
            string[] data = File.ReadAllLines(path);
            homeDirectory = data[0];
            int colorId;
            if (int.TryParse(data[1],out colorId))
            {
                CurrentColor = Color.FromArgb(colorId);
            }

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
                        answer.Add(new object[] { $"[..]", "<DIR>", "<DIR>", dirInfo.Parent.CreationTime });
                    }
                    foreach (var directory in dirInfo.GetDirectories())
                    {
                        answer.Add(new object[] { $"[{directory.Name}]", "<DIR>", "<DIR>", directory.CreationTime });

                    }
                    foreach (var file in dirInfo.GetFiles())
                    {
                        answer.Add(new object[] { file.Name, file.Extension, file.Length.ToString("#,#"), file.CreationTime });
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbLeft.Items.AddRange(DriveInfo.GetDrives());
            cbLeft.SelectedIndex = 0;

            cbRight.Items.AddRange(DriveInfo.GetDrives());
            cbRight.SelectedIndex = 0;
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
        /// <summary>
        /// Метод удаляющий в выбранные папки или файлы в таблице
        /// </summary>
        /// <param name="dgView"></param>
        /// <param name="path"></param>
        private void DeleteFileOrDir(DataGridViewSelectedRowCollection dgViewRows, string path)
        {
            try
            {
                foreach (DataGridViewRow row in dgViewRows)
                {
                    if (row.Cells[0].Value.Equals("[..]"))
                    {
                        continue;
                    }
                    if (row.Cells[1].Value.Equals("<DIR>"))
                    {
                        string nameFolder = row.Cells[0].Value.ToString().Replace("[", "").Replace("]", "");
                        DeleteDir(path + "\\" + nameFolder);
                    }
                    else
                    {
                        File.Delete(path + "\\" + row.Cells[0].Value);
                    }

                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            
                
            
        }

        private void CopySelectedFilesOrDirs(DataGridViewSelectedRowCollection dgViewRows, string oldPath, string newPath)
        {
            try
            {
                foreach (DataGridViewRow row in dgViewRows)
                {
                    if (row.Cells[0].Value.Equals("[..]") || row.Cells[0].Value.Equals(newPath.Split('\\').Last()))
                    {
                        continue;
                    }
                    if (row.Cells[1].Value.Equals("<DIR>"))
                    {
                        string nameDir = row.Cells[0].Value.ToString().Replace("[", "").Replace("]", "");
                        string oldPathN = oldPath + "\\" + nameDir;
                        string newPathN = newPath + "\\" + nameDir;
                        CopyDir(oldPathN, newPathN);
                    }
                    else
                    {
                        string nameFile = row.Cells[0].Value.ToString();
                        string oldPathM = oldPath + "\\" + nameFile;
                        string newPathM = newPath + "\\" + nameFile;
                        if (File.Exists(newPathM) && MessageBox.Show($"{nameFile} is exist, overwrite it ?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            File.Copy(oldPathM, newPathM, true);
                        }
                        else if (!File.Exists(newPath))
                        {
                            File.Copy(oldPathM, newPathM);
                        }
                    }
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            
        }

        private void CopyDir(string oldPath, string newPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            Directory.CreateDirectory(newPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (File.Exists(newPath + "\\" + file.Name) && MessageBox.Show($"{file.Name} is exist, overwrite it ?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    file.CopyTo(newPath + "\\" + file.Name, true);
                }
                else if (!File.Exists(newPath))
                {
                    file.CopyTo(newPath + "\\" + file.Name);
                }
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                CopyDir(dir.FullName, newPath + "\\" + dirInfo.Name);
            }
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
            
            using (var form = new CreateFolderOrFile(cbLeft.Text + currentDirectoryLeft, MousePosition))
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
        private async void deleteToolStripLeft_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete ?", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string disk = cbRight.Text;
            await Task.Run(()=> DeleteFileOrDir(dgViewLeft.SelectedRows, disk + currentDirectoryLeft));
            GoPathLeft(cbLeft.Text + currentDirectoryLeft);
            MessageBox.Show("Delete end");
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
        /// <summary>
        /// Обрабатывает когда фокус падает на левую таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewLeft_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewRight.SelectedRows.Count > 0)
            {
                dgViewRight.ClearSelection();
            }
        }
        /// <summary>
        /// Обрабатывает нажатие на кнопку info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void infoToolStripLeft_Click(object sender, EventArgs e)
        {
            int index = dgViewLeft.CurrentRow.Index;
            string name = dgViewLeft.CurrentRow.Cells[0].Value.ToString();
            string path = cbLeft.Text + currentDirectoryLeft + "\\";
            string dirName = dgViewLeft.CurrentRow.Cells[0].Value.ToString();
            dirName = string.Concat(dirName.Skip(1).Take(dirName.Length - 2).ToArray());
            if (CheckIsFolderLeft(index))
            {
                FileInfoForm infoFormDir = new FileInfoForm(new DirectoryInfo(path + dirName));
                infoFormDir.Show();
                return;
            }
            FileInfoForm infoForm = new FileInfoForm(new FileInfo(path + name));
            infoForm.Show();
        }
        /// <summary>
        /// Обрабатывает нажатие на кнопку копирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void copyToolStripLeft_Click(object sender, EventArgs e)
        {
            string oldPath = cbLeft.Text + currentDirectoryLeft;
            string newPath = cbRight.Text + currentDirectoryRight;
            DataGridViewSelectedRowCollection selectedRows = dgViewLeft.SelectedRows;
            await Task.Run(()=>CopySelectedFilesOrDirs(selectedRows, oldPath, newPath));
            GoPathRight(newPath);
            MessageBox.Show("Copy end");
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
            using (var form = new CreateFolderOrFile(cbRight.Text + currentDirectoryRight, MousePosition))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GoPathRight(cbRight.Text + currentDirectoryRight);
                }
            }
        }

        private async void deleteToolStripRight_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string disk = cbRight.Text;
            await Task.Run(()=>DeleteFileOrDir(dgViewRight.SelectedRows, disk + currentDirectoryRight));
            GoPathRight(cbRight.Text + currentDirectoryRight);
            MessageBox.Show("Delete end");

        }

        private void renameToolStripRight_Click(object sender, EventArgs e)
        {
            dgViewRight.BeginEdit(true);
        }

        private void dgViewRight_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count > 0)
            {
                dgViewLeft.ClearSelection();
            }
        }

        private void infoToolStripRight_Click(object sender, EventArgs e)
        {
            int index = dgViewRight.CurrentRow.Index;
            string name = dgViewRight.CurrentRow.Cells[0].Value.ToString();
            string path = cbRight.Text + currentDirectoryRight + "\\";
            string dirName = dgViewRight.CurrentRow.Cells[0].Value.ToString();
            dirName = string.Concat(dirName.Skip(1).Take(dirName.Length - 2).ToArray());
            if (CheckIsFolderRight(index))
            {
                FileInfoForm infoFormDir = new FileInfoForm(new DirectoryInfo(path + dirName));
                infoFormDir.Show();
                return;
            }
            FileInfoForm infoForm = new FileInfoForm(new FileInfo(path + name));
            infoForm.Show();
        }

        private async void copyToolStripRight_Click(object sender, EventArgs e)
        {
            string newPath = cbLeft.Text + currentDirectoryLeft;
            string oldPath = cbRight.Text + currentDirectoryRight;
            DataGridViewSelectedRowCollection selectedRows = dgViewRight.SelectedRows;
            await Task.Run(() => CopySelectedFilesOrDirs(selectedRows, oldPath, newPath));
            GoPathLeft(newPath);
            MessageBox.Show("Copy end");

        }
        #endregion

        private void bCreate_Click(object sender, EventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count>0)
            {
                createToolStripLeft.PerformClick();
                return;
            }
            createToolStripRight.PerformClick();
        }

        private void bSetting_Click(object sender, EventArgs e)
        {
            
            using (var settingForm = new SettingsForm(homeDirectory))
            {
                settingForm.Font = this.Font;
                settingForm.BackColor = this.CurrentColor;
                if (settingForm.ShowDialog()!=DialogResult.OK)
                {
                    return;
                }
                this.Font = settingForm.CurrentFont;
                CurrentColor = settingForm.CurrentColor;
                this.Width += 1;
                this.panelTools.BackColor = CurrentColor;
                
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count > 0)
            {
                deleteToolStripLeft.PerformClick();
                return;
            }
            deleteToolStripRight.PerformClick();
        }

        private void rightPanelInSplit_SizeChanged(object sender, EventArgs e)
        {
            dgViewRight.Width = rightPanelInSplit.Width;
        }

        private void bRename_Click(object sender, EventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count > 0)
            {
                renameToolStripLeft.PerformClick();
                return;
            }
            renameToolStripRight.PerformClick();
        }

        private async void zipToolStripLeft_Click(object sender, EventArgs e)
        {
            string filePath;
            string currentDir = cbLeft.Text + currentDirectoryLeft;
            using (var formZip = new CreateZipForm(currentDir))
            {
                if (formZip.ShowDialog() !=DialogResult.OK)
                {
                    return;
                }
                filePath = formZip.FilePath;
            }
            await Task.Run(()=>ZipFileDir(dgViewLeft.SelectedRows, filePath, currentDir));
            GoPathLeft(currentDir);
            MessageBox.Show("Zip end");
        }

        private void ZipFileDir(DataGridViewSelectedRowCollection dgViewRows, string filePath, string dir)
        {
            int brieflyDir = 0;
            while (Directory.Exists(dir+"\\"+brieflyDir))
            {
                brieflyDir++;
            }
            string pathNewDir = dir + "\\" + brieflyDir;
            Directory.CreateDirectory(pathNewDir);
            CopySelectedFilesOrDirs(dgViewRows, dir, pathNewDir);
            ZipFile.CreateFromDirectory(pathNewDir, filePath);
            DeleteDir(pathNewDir);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count > 0)
            {
                copyToolStripLeft.PerformClick();
                return;
            }
            copyToolStripRight.PerformClick();
        }

        private async void zipToolStripRight_Click(object sender, EventArgs e)
        {
            string filePath;
            string currentDir = cbRight.Text + currentDirectoryRight;
            using (var formZip = new CreateZipForm(currentDir))
            {
                if (formZip.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                filePath = formZip.FilePath;
            }
            await Task.Run(() => ZipFileDir(dgViewRight.SelectedRows, filePath, currentDir));
            GoPathRight(currentDir);
            MessageBox.Show("Zip end");
        }

        private void bZip_Click(object sender, EventArgs e)
        {
            if (dgViewLeft.SelectedRows.Count > 0)
            {
                zipToolStripLeft.PerformClick();
                return;
            }
            zipToolStripRight.PerformClick();
        }
    }
}
