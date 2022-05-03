
namespace totalCMD
{
    partial class CreateZipForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lRename = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 45);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(429, 26);
            this.tbName.TabIndex = 0;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(12, 97);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(99, 32);
            this.bOk.TabIndex = 1;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(324, 97);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(99, 32);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lRename
            // 
            this.lRename.AutoSize = true;
            this.lRename.ForeColor = System.Drawing.Color.DarkRed;
            this.lRename.Location = new System.Drawing.Point(13, 74);
            this.lRename.Name = "lRename";
            this.lRename.Size = new System.Drawing.Size(226, 20);
            this.lRename.TabIndex = 3;
            this.lRename.Text = "This file is exist, please rename";
            this.lRename.Visible = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 9);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(236, 20);
            this.lName.TabIndex = 4;
            this.lName.Text = "Enter zip-file name without \".zip\"";
            // 
            // CreateZipForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(453, 156);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lRename);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tbName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateZipForm";
            this.Text = "CreateZipForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lRename;
        private System.Windows.Forms.Label lName;
    }
}