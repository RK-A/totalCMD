
namespace totalCMD
{
    partial class FileInfoForm
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
            this.tbLength = new System.Windows.Forms.TextBox();
            this.tbCreationTime = new System.Windows.Forms.TextBox();
            this.tbLastWritetime = new System.Windows.Forms.TextBox();
            this.tbDirectionName = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 12);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(238, 20);
            this.tbName.TabIndex = 0;
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(12, 51);
            this.tbLength.Name = "tbLength";
            this.tbLength.ReadOnly = true;
            this.tbLength.Size = new System.Drawing.Size(238, 20);
            this.tbLength.TabIndex = 1;
            // 
            // tbCreationTime
            // 
            this.tbCreationTime.Location = new System.Drawing.Point(12, 94);
            this.tbCreationTime.Name = "tbCreationTime";
            this.tbCreationTime.ReadOnly = true;
            this.tbCreationTime.Size = new System.Drawing.Size(238, 20);
            this.tbCreationTime.TabIndex = 2;
            // 
            // tbLastWritetime
            // 
            this.tbLastWritetime.Location = new System.Drawing.Point(12, 136);
            this.tbLastWritetime.Name = "tbLastWritetime";
            this.tbLastWritetime.ReadOnly = true;
            this.tbLastWritetime.Size = new System.Drawing.Size(238, 20);
            this.tbLastWritetime.TabIndex = 3;
            // 
            // tbDirectionName
            // 
            this.tbDirectionName.Location = new System.Drawing.Point(12, 176);
            this.tbDirectionName.Name = "tbDirectionName";
            this.tbDirectionName.ReadOnly = true;
            this.tbDirectionName.Size = new System.Drawing.Size(238, 20);
            this.tbDirectionName.TabIndex = 4;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(175, 225);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 5;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOK_Click);
            // 
            // FileInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 260);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tbDirectionName);
            this.Controls.Add(this.tbLastWritetime);
            this.Controls.Add(this.tbCreationTime);
            this.Controls.Add(this.tbLength);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileInfoForm";
            this.Text = "FileInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.TextBox tbCreationTime;
        private System.Windows.Forms.TextBox tbLastWritetime;
        private System.Windows.Forms.TextBox tbDirectionName;
        private System.Windows.Forms.Button bOk;
    }
}