namespace csharpMediaPlayer
{
    partial class MediaForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("音乐");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("影片");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_saveList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_loadList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_setFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_setFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_setWebResource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_aboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.wmpCtrl = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.tsmi_loadList,
            this.tsmi_System});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_saveList});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(44, 21);
            this.tsmi_File.Text = "文件";
            // 
            // tsmi_saveList
            // 
            this.tsmi_saveList.Name = "tsmi_saveList";
            this.tsmi_saveList.Size = new System.Drawing.Size(148, 22);
            this.tsmi_saveList.Text = "保存文件列表";
            this.tsmi_saveList.Click += new System.EventHandler(this.tsmi_saveList_Click);
            // 
            // tsmi_loadList
            // 
            this.tsmi_loadList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_setFolder,
            this.tsmi_setFile,
            this.tsmi_setWebResource});
            this.tsmi_loadList.Name = "tsmi_loadList";
            this.tsmi_loadList.Size = new System.Drawing.Size(92, 21);
            this.tsmi_loadList.Text = "加载播放列表";
            // 
            // tsmi_setFolder
            // 
            this.tsmi_setFolder.Name = "tsmi_setFolder";
            this.tsmi_setFolder.Size = new System.Drawing.Size(148, 22);
            this.tsmi_setFolder.Text = "指定文件夹";
            this.tsmi_setFolder.Click += new System.EventHandler(this.tsmi_setFolder_Click);
            // 
            // tsmi_setFile
            // 
            this.tsmi_setFile.Name = "tsmi_setFile";
            this.tsmi_setFile.Size = new System.Drawing.Size(148, 22);
            this.tsmi_setFile.Text = "指定文件";
            this.tsmi_setFile.Click += new System.EventHandler(this.tsmi_setFile_Click);
            // 
            // tsmi_setWebResource
            // 
            this.tsmi_setWebResource.Name = "tsmi_setWebResource";
            this.tsmi_setWebResource.Size = new System.Drawing.Size(148, 22);
            this.tsmi_setWebResource.Text = "指定网络资源";
            this.tsmi_setWebResource.Click += new System.EventHandler(this.tsmi_setWebResource_Click);
            // 
            // tsmi_System
            // 
            this.tsmi_System.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_aboutUs,
            this.tsmi_exit});
            this.tsmi_System.Name = "tsmi_System";
            this.tsmi_System.Size = new System.Drawing.Size(44, 21);
            this.tsmi_System.Text = "系统";
            // 
            // tsmi_aboutUs
            // 
            this.tsmi_aboutUs.Name = "tsmi_aboutUs";
            this.tsmi_aboutUs.Size = new System.Drawing.Size(180, 22);
            this.tsmi_aboutUs.Text = "关于我们";
            this.tsmi_aboutUs.Click += new System.EventHandler(this.tsmi_aboutUs_Click);
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            this.tsmi_exit.Size = new System.Drawing.Size(180, 22);
            this.tsmi_exit.Text = "退出";
            this.tsmi_exit.Click += new System.EventHandler(this.tsmi_exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wmpCtrl);
            this.splitContainer1.Size = new System.Drawing.Size(693, 425);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "music";
            treeNode1.Text = "音乐";
            treeNode2.Name = "movie";
            treeNode2.Text = "影片";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(231, 425);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // wmpCtrl
            // 
            this.wmpCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmpCtrl.Enabled = true;
            this.wmpCtrl.Location = new System.Drawing.Point(0, 0);
            this.wmpCtrl.Name = "wmpCtrl";
            this.wmpCtrl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpCtrl.OcxState")));
            this.wmpCtrl.Size = new System.Drawing.Size(458, 425);
            this.wmpCtrl.TabIndex = 0;
            // 
            // MediaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(693, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MediaForm";
            this.Text = "c#多媒体播放器";
            this.Load += new System.EventHandler(this.MediaForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wmpCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmpCtrl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_File;
        private System.Windows.Forms.ToolStripMenuItem tsmi_saveList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_loadList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_setFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmi_setFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_setWebResource;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System;
        private System.Windows.Forms.ToolStripMenuItem tsmi_aboutUs;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
    }
}

