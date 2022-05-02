
namespace totalCMD
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bFont = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bBackColor = new System.Windows.Forms.Button();
            this.tbHomeDir = new System.Windows.Forms.TextBox();
            this.lTextBox = new System.Windows.Forms.Label();
            this.cbDisk = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bFont
            // 
            this.bFont.Location = new System.Drawing.Point(16, 15);
            this.bFont.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bFont.Name = "bFont";
            this.bFont.Size = new System.Drawing.Size(100, 28);
            this.bFont.TabIndex = 1;
            this.bFont.Text = "Font";
            this.bFont.UseVisualStyleBackColor = true;
            this.bFont.Click += new System.EventHandler(this.bFont_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(16, 178);
            this.bOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 28);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(232, 178);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 28);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bBackColor
            // 
            this.bBackColor.Location = new System.Drawing.Point(16, 50);
            this.bBackColor.Name = "bBackColor";
            this.bBackColor.Size = new System.Drawing.Size(100, 30);
            this.bBackColor.TabIndex = 4;
            this.bBackColor.Text = "Back color";
            this.bBackColor.UseVisualStyleBackColor = true;
            this.bBackColor.Click += new System.EventHandler(this.bBackColor_Click);
            // 
            // tbHomeDir
            // 
            this.tbHomeDir.Location = new System.Drawing.Point(53, 117);
            this.tbHomeDir.Name = "tbHomeDir";
            this.tbHomeDir.Size = new System.Drawing.Size(292, 23);
            this.tbHomeDir.TabIndex = 5;
            // 
            // lTextBox
            // 
            this.lTextBox.AutoSize = true;
            this.lTextBox.Location = new System.Drawing.Point(13, 97);
            this.lTextBox.Name = "lTextBox";
            this.lTextBox.Size = new System.Drawing.Size(104, 17);
            this.lTextBox.TabIndex = 6;
            this.lTextBox.Text = "Home directory";
            // 
            // cbDisk
            // 
            this.cbDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisk.FormattingEnabled = true;
            this.cbDisk.Location = new System.Drawing.Point(16, 116);
            this.cbDisk.Name = "cbDisk";
            this.cbDisk.Size = new System.Drawing.Size(39, 24);
            this.cbDisk.TabIndex = 40;
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(357, 222);
            this.Controls.Add(this.cbDisk);
            this.Controls.Add(this.lTextBox);
            this.Controls.Add(this.tbHomeDir);
            this.Controls.Add(this.bBackColor);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bFont);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(373, 261);
            this.MinimumSize = new System.Drawing.Size(373, 261);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bFont;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bBackColor;
        private System.Windows.Forms.TextBox tbHomeDir;
        private System.Windows.Forms.Label lTextBox;
        private System.Windows.Forms.ComboBox cbDisk;
    }
}