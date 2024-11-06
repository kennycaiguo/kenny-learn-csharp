using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;

//vs2022小技巧,ctrl+d是向下复制功能快捷键
namespace csharpMediaPlayer
{
    public partial class MediaForm : Form
    {
        /// <summary>
        /// 保存播放列表的成员
        /// </summary>
        List<FileModel> filesList = new List<FileModel>();

        public MediaForm()
        {
            InitializeComponent();
            //设置配置信息
            this.Text = Common.projectName;//读取配置信息修改窗体标题
        }

        private void MediaForm_Load(object sender, EventArgs e)
        {
            //在这里加载一些需要在窗体显示之前就要加载的内容如上一次退出之前保存的播放列表等等
            //利用反序列化加载文件内容到文件列表
            string filePath = Environment.CurrentDirectory + "\\playlist.txt";
            LoadPlayListFromFile(filePath);
        }
        private void LoadPlayListFromFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();
            filesList = (List<FileModel>)b.Deserialize(fs);
            foreach (var item in filesList)
            {
                #region 添加文件到treeView
                TreeNode node = new TreeNode();
                node.Name = item.FileGuid;
                node.Text = item.FileName;
                node.Tag = item;
                if (item.FileType == FileType.Music) //是音乐文件就添加到Music节点
                {
                    treeView1.Nodes[0].Nodes.Add(node);
                }
                else if (item.FileType == FileType.Movie) //是视频文件就添加到Movie节点
                {
                    treeView1.Nodes[1].Nodes.Add(node);
                }

                #endregion
            }
        }
        private void tsmi_setFolder_Click(object sender, EventArgs e)
        {
            //指定文件夹菜单项的事件处理代码
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(DialogResult.OK == fbd.ShowDialog())
            {
                string folder = fbd.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(folder);//可以用一个文件夹来创建文件夹信息对象
                foreach(FileInfo fi in di.GetFiles())
                {
                    //调用封装的方法来把文件添加到treeView控件中
                    //在添加文件之前其实需要判断一下他的后缀名是否是媒体文件如mp3,mp4,wmv,avi等等
                    AddNode(fi);
                }
            }
        }
        private void AddNode(FileInfo fi)
        {
            #region 添加文件到文件列表
            //先用我们的FileModel类实例化一个对象
            FileModel fileModel = new FileModel();
            //生成文件的唯一标识
            fileModel.FileGuid = Guid.NewGuid().ToString();
            fileModel.FileName = fi.Name;//文件名称,只是用来显示
            fileModel.FilePath = fi.FullName;//文件的完整路径,这个才是可以播放的文件url
            if (fi.Extension == ".mp3" || fi.Extension == ".wma" || fi.Extension == ".wav")//后缀名带.
            {
                fileModel.FileType = FileType.Music;
            }
            else if (fi.Extension == ".mp4" || fi.Extension == ".wmv" || fi.Extension == ".avi" || fi.Extension == ".3gp")
            {
                fileModel.FileType = FileType.Movie;
            }
            fileModel.ResourceType = ResourceType.Local;//先把资源类型设置为本地资源
            fileModel.OrderNo = this.filesList.Count + 1;
            this.filesList.Add(fileModel);//添加到文件列表
            #endregion
            #region 添加文件到treeView
            TreeNode node = new TreeNode();
            node.Name = fileModel.FileGuid; 
            node.Text =fileModel.FileName;
            node.Tag = fileModel;
            if (fileModel.FileType == FileType.Music) //是音乐文件就添加到Music节点
            {
                treeView1.Nodes[0].Nodes.Add(node);
            }
            else if (fileModel.FileType == FileType.Movie) //是视频文件就添加到Movie节点
            {
                treeView1.Nodes[1].Nodes.Add(node);
            }

            #endregion
        }

        private void tsmi_setFile_Click(object sender, EventArgs e)
        {
            //指定文件菜单项的事件处理代码
            OpenFileDialog dlg = new OpenFileDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                FileInfo fi = new FileInfo(dlg.FileName);
                AddNode(fi); 
            }
        }

        private void tsmi_setWebResource_Click(object sender, EventArgs e)
        {
            //指定网络资源菜单项的事件处理代码
            NetworkForm nf = new NetworkForm();//创建网络资源窗体的实例
            nf.SetFileModel += Nf_SetFileModel; //注册事件委托的处理函数
            nf.ShowDialog();//显示窗体
        }

        //实现事件委托的处理函数,也叫做回调函数
        private void Nf_SetFileModel(FileModel model)
        {
            //把返回的文件模型添加到文件列表
            model.OrderNo = this.filesList.Count + 1;
            this.filesList.Add(model);//吧NetworkForm传递过来的文件模型对象添加到文件列表
            //添加节点
            TreeNode node = new TreeNode();
            node.Name = model.FileGuid;
            node.Text = model.FileName;
            node.Tag = model;
            if (model.FileType == FileType.Music) //是音乐文件就添加到Music节点
            {
                treeView1.Nodes[0].Nodes.Add(node);
            }
            else if (model.FileType == FileType.Movie) //是视频文件就添加到Movie节点
            {
                treeView1.Nodes[1].Nodes.Add(node);
            }

        }

        /// <summary>
        /// 实现双击播放treeview上面的媒体文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            //DoPlay1();//ok,就是逻辑比较简单.
            DoPlay2();
        }
        private void DoPlay1() //自己写的方法
        {
            foreach (var item in filesList)
            {
                if (item.FileName == treeView1.SelectedNode.Text)
                {
                    wmpCtrl.URL = item.FilePath;
                    break;
                }
            }
        }
        private void DoPlay2()//还是我的方法
        {
            //获取选中的treeView节点
            FileModel fileModel = (FileModel)treeView1.SelectedNode.Tag;
            //需要先判断wmp控件的状态
            if (wmpCtrl.playState != WMPLib.WMPPlayState.wmppsPaused) //如果不是暂停状态
            {
                wmpCtrl.URL = fileModel.FilePath;
            }
            else
            {
                wmpCtrl.Ctlcontrols.stop();
                wmpCtrl.URL = fileModel.FilePath;
            }
        }
        private void DoPlay3()//老师的方法
        {
            //获取选中的treeView节点
            FileModel fileModel = (FileModel)treeView1.SelectedNode.Tag;
            //需要先判断wmp控件的状态
            if (wmpCtrl.playState != WMPLib.WMPPlayState.wmppsPaused) //如果不是暂停状态
            {
                wmpCtrl.URL = fileModel.FilePath;
            }
            wmpCtrl.Ctlcontrols.play();
        }

        //把文件列表保存到一个文本文件中
        private void tsmi_saveList_Click(object sender, EventArgs e)
        {
            if(this.filesList.Count ==0)
            {
                MessageBox.Show("播放列表为空,请添加歌曲到播放列表");
                return;
            }
            //利用序列化把文件列表保存到文件
            string savePath = Environment.CurrentDirectory + "\\playlist.txt";
            FileStream fs = new FileStream(savePath, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs,filesList);
            fs.Close();
            MessageBox.Show("播放列表已经保存");
        }

        private void tsmi_aboutUs_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void tsmi_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
