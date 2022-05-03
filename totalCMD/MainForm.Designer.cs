
namespace totalCMD
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgViewLeft = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPathLeft = new System.Windows.Forms.TextBox();
            this.cbLeft = new System.Windows.Forms.ComboBox();
            this.rightPanelInSplit = new System.Windows.Forms.Panel();
            this.dgViewRight = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPathRight = new System.Windows.Forms.TextBox();
            this.cbRight = new System.Windows.Forms.ComboBox();
            this.panelTools = new System.Windows.Forms.Panel();
            this.bRename = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.MenuStripLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.zipToolStripLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripRight = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripRight = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripRight = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripRight = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripRight = new System.Windows.Forms.ToolStripMenuItem();
            this.zipToolStripRight = new System.Windows.Forms.ToolStripMenuItem();
            this.bSetting = new System.Windows.Forms.Button();
            this.bZip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewLeft)).BeginInit();
            this.rightPanelInSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewRight)).BeginInit();
            this.panelTools.SuspendLayout();
            this.MenuStripLeft.SuspendLayout();
            this.MenuStripRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgViewLeft);
            this.splitContainer.Panel1.Controls.Add(this.tbPathLeft);
            this.splitContainer.Panel1.Controls.Add(this.cbLeft);
            this.splitContainer.Panel1.SizeChanged += new System.EventHandler(this.splitContainer1_Panel1_SizeChanged);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rightPanelInSplit);
            this.splitContainer.Panel2.Controls.Add(this.panelTools);
            this.splitContainer.Size = new System.Drawing.Size(995, 551);
            this.splitContainer.SplitterDistance = 410;
            this.splitContainer.TabIndex = 0;
            // 
            // dgViewLeft
            // 
            this.dgViewLeft.AllowUserToAddRows = false;
            this.dgViewLeft.AllowUserToDeleteRows = false;
            this.dgViewLeft.AllowUserToResizeRows = false;
            this.dgViewLeft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewLeft.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgViewLeft.BackgroundColor = System.Drawing.Color.White;
            this.dgViewLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewLeft.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgViewLeft.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewLeft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgViewLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgViewLeft.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgViewLeft.EnableHeadersVisualStyles = false;
            this.dgViewLeft.Location = new System.Drawing.Point(-2, 20);
            this.dgViewLeft.Name = "dgViewLeft";
            this.dgViewLeft.RowHeadersVisible = false;
            this.dgViewLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewLeft.ShowEditingIcon = false;
            this.dgViewLeft.ShowRowErrors = false;
            this.dgViewLeft.Size = new System.Drawing.Size(412, 531);
            this.dgViewLeft.TabIndex = 13;
            this.dgViewLeft.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgViewLeft_CellBeginEdit);
            this.dgViewLeft.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewLeft_CellDoubleClick);
            this.dgViewLeft.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewLeft_CellEndEdit);
            this.dgViewLeft.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgViewLeft_CellMouseDown);
            this.dgViewLeft.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewLeft_RowEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 91;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 50.7837F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 98.38738F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Size";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 150.8289F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // tbPathLeft
            // 
            this.tbPathLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPathLeft.Location = new System.Drawing.Point(39, 0);
            this.tbPathLeft.Name = "tbPathLeft";
            this.tbPathLeft.Size = new System.Drawing.Size(371, 20);
            this.tbPathLeft.TabIndex = 12;
            this.tbPathLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPathLeft_KeyDown);
            // 
            // cbLeft
            // 
            this.cbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeft.FormattingEnabled = true;
            this.cbLeft.Location = new System.Drawing.Point(0, 0);
            this.cbLeft.Name = "cbLeft";
            this.cbLeft.Size = new System.Drawing.Size(39, 21);
            this.cbLeft.TabIndex = 11;
            this.cbLeft.TextChanged += new System.EventHandler(this.cbLeft_TextChanged);
            // 
            // rightPanelInSplit
            // 
            this.rightPanelInSplit.Controls.Add(this.dgViewRight);
            this.rightPanelInSplit.Controls.Add(this.tbPathRight);
            this.rightPanelInSplit.Controls.Add(this.cbRight);
            this.rightPanelInSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanelInSplit.Location = new System.Drawing.Point(68, 0);
            this.rightPanelInSplit.Name = "rightPanelInSplit";
            this.rightPanelInSplit.Size = new System.Drawing.Size(513, 551);
            this.rightPanelInSplit.TabIndex = 39;
            this.rightPanelInSplit.SizeChanged += new System.EventHandler(this.rightPanelInSplit_SizeChanged);
            // 
            // dgViewRight
            // 
            this.dgViewRight.AllowUserToAddRows = false;
            this.dgViewRight.AllowUserToDeleteRows = false;
            this.dgViewRight.AllowUserToResizeRows = false;
            this.dgViewRight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewRight.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgViewRight.BackgroundColor = System.Drawing.Color.White;
            this.dgViewRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewRight.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgViewRight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgViewRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgViewRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgViewRight.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgViewRight.EnableHeadersVisualStyles = false;
            this.dgViewRight.Location = new System.Drawing.Point(6, 20);
            this.dgViewRight.Name = "dgViewRight";
            this.dgViewRight.RowHeadersVisible = false;
            this.dgViewRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewRight.ShowEditingIcon = false;
            this.dgViewRight.ShowRowErrors = false;
            this.dgViewRight.Size = new System.Drawing.Size(507, 531);
            this.dgViewRight.TabIndex = 42;
            this.dgViewRight.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgViewRight_CellBeginEdit);
            this.dgViewRight.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewRight_CellDoubleClick);
            this.dgViewRight.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewRight_CellEndEdit);
            this.dgViewRight.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgViewRight_CellMouseDown);
            this.dgViewRight.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewRight_RowEnter);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 91;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.FillWeight = 50.7837F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 55;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.FillWeight = 98.38738F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Size";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 51;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 150.8289F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // tbPathRight
            // 
            this.tbPathRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPathRight.Location = new System.Drawing.Point(39, 0);
            this.tbPathRight.Name = "tbPathRight";
            this.tbPathRight.Size = new System.Drawing.Size(474, 20);
            this.tbPathRight.TabIndex = 41;
            this.tbPathRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPathRight_KeyDown);
            // 
            // cbRight
            // 
            this.cbRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRight.FormattingEnabled = true;
            this.cbRight.Location = new System.Drawing.Point(0, 0);
            this.cbRight.Name = "cbRight";
            this.cbRight.Size = new System.Drawing.Size(39, 21);
            this.cbRight.TabIndex = 39;
            this.cbRight.SelectedIndexChanged += new System.EventHandler(this.cbRight_SelectedIndexChanged);
            // 
            // panelTools
            // 
            this.panelTools.AutoSize = true;
            this.panelTools.BackColor = System.Drawing.Color.White;
            this.panelTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTools.Controls.Add(this.bZip);
            this.panelTools.Controls.Add(this.bRename);
            this.panelTools.Controls.Add(this.bDelete);
            this.panelTools.Controls.Add(this.bSetting);
            this.panelTools.Controls.Add(this.bCreate);
            this.panelTools.Controls.Add(this.bCopy);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(68, 551);
            this.panelTools.TabIndex = 32;
            // 
            // bRename
            // 
            this.bRename.AutoSize = true;
            this.bRename.Location = new System.Drawing.Point(3, 189);
            this.bRename.Name = "bRename";
            this.bRename.Size = new System.Drawing.Size(57, 36);
            this.bRename.TabIndex = 4;
            this.bRename.Text = "Rename";
            this.bRename.UseVisualStyleBackColor = true;
            this.bRename.Click += new System.EventHandler(this.bRename_Click);
            // 
            // bDelete
            // 
            this.bDelete.AutoSize = true;
            this.bDelete.Location = new System.Drawing.Point(4, 147);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(57, 36);
            this.bDelete.TabIndex = 3;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bCreate
            // 
            this.bCreate.AutoSize = true;
            this.bCreate.Location = new System.Drawing.Point(4, 106);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(57, 35);
            this.bCreate.TabIndex = 1;
            this.bCreate.Text = "Create";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // bCopy
            // 
            this.bCopy.AutoSize = true;
            this.bCopy.Location = new System.Drawing.Point(4, 63);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(57, 36);
            this.bCopy.TabIndex = 0;
            this.bCopy.Text = "Copy";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // MenuStripLeft
            // 
            this.MenuStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripLeft,
            this.deleteToolStripLeft,
            this.renameToolStripLeft,
            this.copyToolStripLeft,
            this.infoToolStripLeft,
            this.zipToolStripLeft});
            this.MenuStripLeft.Name = "MenuStripLeft";
            this.MenuStripLeft.Size = new System.Drawing.Size(118, 136);
            // 
            // createToolStripLeft
            // 
            this.createToolStripLeft.Name = "createToolStripLeft";
            this.createToolStripLeft.Size = new System.Drawing.Size(117, 22);
            this.createToolStripLeft.Text = "Create";
            this.createToolStripLeft.Click += new System.EventHandler(this.createToolStripLeft_Click);
            // 
            // deleteToolStripLeft
            // 
            this.deleteToolStripLeft.Name = "deleteToolStripLeft";
            this.deleteToolStripLeft.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripLeft.Text = "Delete";
            this.deleteToolStripLeft.Click += new System.EventHandler(this.deleteToolStripLeft_Click);
            // 
            // renameToolStripLeft
            // 
            this.renameToolStripLeft.Name = "renameToolStripLeft";
            this.renameToolStripLeft.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripLeft.Text = "Rename";
            this.renameToolStripLeft.Click += new System.EventHandler(this.renameToolStripLeft_Click);
            // 
            // copyToolStripLeft
            // 
            this.copyToolStripLeft.Name = "copyToolStripLeft";
            this.copyToolStripLeft.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripLeft.Text = "Copy";
            this.copyToolStripLeft.Click += new System.EventHandler(this.copyToolStripLeft_Click);
            // 
            // infoToolStripLeft
            // 
            this.infoToolStripLeft.Name = "infoToolStripLeft";
            this.infoToolStripLeft.Size = new System.Drawing.Size(117, 22);
            this.infoToolStripLeft.Text = "Info";
            this.infoToolStripLeft.Click += new System.EventHandler(this.infoToolStripLeft_Click);
            // 
            // zipToolStripLeft
            // 
            this.zipToolStripLeft.Name = "zipToolStripLeft";
            this.zipToolStripLeft.Size = new System.Drawing.Size(117, 22);
            this.zipToolStripLeft.Text = "To zip";
            this.zipToolStripLeft.Click += new System.EventHandler(this.zipToolStripLeft_Click);
            // 
            // MenuStripRight
            // 
            this.MenuStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripRight,
            this.deleteToolStripRight,
            this.renameToolStripRight,
            this.copyToolStripRight,
            this.infoToolStripRight,
            this.zipToolStripRight});
            this.MenuStripRight.Name = "MenuStripLeft";
            this.MenuStripRight.Size = new System.Drawing.Size(118, 136);
            // 
            // createToolStripRight
            // 
            this.createToolStripRight.Name = "createToolStripRight";
            this.createToolStripRight.Size = new System.Drawing.Size(117, 22);
            this.createToolStripRight.Text = "Create";
            this.createToolStripRight.Click += new System.EventHandler(this.createToolStripRight_Click);
            // 
            // deleteToolStripRight
            // 
            this.deleteToolStripRight.Name = "deleteToolStripRight";
            this.deleteToolStripRight.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripRight.Text = "Delete";
            this.deleteToolStripRight.Click += new System.EventHandler(this.deleteToolStripRight_Click);
            // 
            // renameToolStripRight
            // 
            this.renameToolStripRight.Name = "renameToolStripRight";
            this.renameToolStripRight.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripRight.Text = "Rename";
            this.renameToolStripRight.Click += new System.EventHandler(this.renameToolStripRight_Click);
            // 
            // copyToolStripRight
            // 
            this.copyToolStripRight.Name = "copyToolStripRight";
            this.copyToolStripRight.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripRight.Text = "Copy";
            this.copyToolStripRight.Click += new System.EventHandler(this.copyToolStripRight_Click);
            // 
            // infoToolStripRight
            // 
            this.infoToolStripRight.Name = "infoToolStripRight";
            this.infoToolStripRight.Size = new System.Drawing.Size(117, 22);
            this.infoToolStripRight.Text = "Info";
            this.infoToolStripRight.Click += new System.EventHandler(this.infoToolStripRight_Click);
            // 
            // zipToolStripRight
            // 
            this.zipToolStripRight.Name = "zipToolStripRight";
            this.zipToolStripRight.Size = new System.Drawing.Size(117, 22);
            this.zipToolStripRight.Text = "To zip";
            this.zipToolStripRight.Click += new System.EventHandler(this.zipToolStripRight_Click);
            // 
            // bSetting
            // 
            this.bSetting.BackgroundImage = global::totalCMD.Properties.Resources.setting;
            this.bSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bSetting.Location = new System.Drawing.Point(4, 287);
            this.bSetting.Name = "bSetting";
            this.bSetting.Size = new System.Drawing.Size(57, 44);
            this.bSetting.TabIndex = 2;
            this.bSetting.UseVisualStyleBackColor = true;
            this.bSetting.Click += new System.EventHandler(this.bSetting_Click);
            // 
            // bZip
            // 
            this.bZip.AutoSize = true;
            this.bZip.Location = new System.Drawing.Point(3, 231);
            this.bZip.Name = "bZip";
            this.bZip.Size = new System.Drawing.Size(57, 36);
            this.bZip.TabIndex = 5;
            this.bZip.Text = "ZIP";
            this.bZip.UseVisualStyleBackColor = true;
            this.bZip.Click += new System.EventHandler(this.bZip_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(995, 551);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "TotalCommander";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewLeft)).EndInit();
            this.rightPanelInSplit.ResumeLayout(false);
            this.rightPanelInSplit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewRight)).EndInit();
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            this.MenuStripLeft.ResumeLayout(false);
            this.MenuStripRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgViewLeft;
        private System.Windows.Forms.TextBox tbPathLeft;
        private System.Windows.Forms.ComboBox cbLeft;
        private System.Windows.Forms.ContextMenuStrip MenuStripLeft;
        private System.Windows.Forms.ToolStripMenuItem createToolStripLeft;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripLeft;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripLeft;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripLeft;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripLeft;
        private System.Windows.Forms.ToolStripMenuItem zipToolStripLeft;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ContextMenuStrip MenuStripRight;
        private System.Windows.Forms.ToolStripMenuItem createToolStripRight;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripRight;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripRight;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripRight;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripRight;
        private System.Windows.Forms.ToolStripMenuItem zipToolStripRight;
        private System.Windows.Forms.Panel rightPanelInSplit;
        private System.Windows.Forms.DataGridView dgViewRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox tbPathRight;
        private System.Windows.Forms.ComboBox cbRight;
        private System.Windows.Forms.Button bSetting;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bRename;
        private System.Windows.Forms.Button bZip;
    }
}

