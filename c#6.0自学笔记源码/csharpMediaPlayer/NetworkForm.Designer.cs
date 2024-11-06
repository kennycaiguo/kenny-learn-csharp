namespace csharpMediaPlayer
{
    partial class NetworkForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbnMusic = new System.Windows.Forms.RadioButton();
            this.rbnMovie = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "网络路径:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(92, 53);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(296, 21);
            this.tbFileName.TabIndex = 1;
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(92, 83);
            this.tbURL.Multiline = true;
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(296, 91);
            this.tbURL.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(394, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "如:xx.mp3,xx.mp4";
            // 
            // rbnMusic
            // 
            this.rbnMusic.AutoSize = true;
            this.rbnMusic.Checked = true;
            this.rbnMusic.Location = new System.Drawing.Point(92, 28);
            this.rbnMusic.Name = "rbnMusic";
            this.rbnMusic.Size = new System.Drawing.Size(53, 16);
            this.rbnMusic.TabIndex = 2;
            this.rbnMusic.TabStop = true;
            this.rbnMusic.Text = "Music";
            this.rbnMusic.UseVisualStyleBackColor = true;
            // 
            // rbnMovie
            // 
            this.rbnMovie.AutoSize = true;
            this.rbnMovie.Location = new System.Drawing.Point(193, 28);
            this.rbnMovie.Name = "rbnMovie";
            this.rbnMovie.Size = new System.Drawing.Size(53, 16);
            this.rbnMovie.TabIndex = 2;
            this.rbnMovie.Text = "Movie";
            this.rbnMovie.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(92, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 242);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbnMovie);
            this.Controls.Add(this.rbnMusic);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "NetworkForm";
            this.Text = "添加网络媒体资源";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbnMusic;
        private System.Windows.Forms.RadioButton rbnMovie;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}