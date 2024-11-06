using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpMediaPlayer
{
    public partial class NetworkForm : Form
    {
        public NetworkForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 定义一个委托事件,他是一种数据类型,相当于在内存里面指定一个存放函数的内存地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public event Action<FileModel> SetFileModel;

        private void btnSave_Click(object sender, EventArgs e)
        {
            //传递数据给MediaForm并且关闭网络资源对话框
            //需要先把数据封装到FileModel对象中
            FileModel fileModel = new FileModel();
           
            //生成文件的唯一标识
            fileModel.FileGuid = Guid.NewGuid().ToString();
            fileModel.FileName = tbFileName.Text.Trim();//文件名称,只是用来显示
            fileModel.FilePath =tbURL.Text.Trim();//文件的完整路径,这个才是可以播放的文件url
            fileModel.FileType = this.rbnMusic.Checked ? FileType.Music : FileType.Movie;
            fileModel.ResourceType = ResourceType.Network;//先把资源类型设置为本地资源

            SetFileModel(fileModel);//需要使用委托事件的地方
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
