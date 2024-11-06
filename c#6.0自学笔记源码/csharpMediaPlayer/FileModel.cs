using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpMediaPlayer
{
    /// <summary>
    /// 处理媒体文件的类
    /// </summary>
    [Serializable]
    public class FileModel
    {
        public string FileGuid{ get; set; } //文件的全局唯一标识符
        public string FileName{ get; set; } //文件名
        public FileType FileType{ get; set; } //文件类型,是一个枚举变量
        public string FilePath { get; set; }//本地路径或者网络路径都可以
        public int OrderNo { get; set; } //排序编号
        public ResourceType ResourceType { get; set; } //资源类型,是一个枚举变量

    }
    public enum ResourceType //资源类型枚举,注意c#中枚举的写法
    {   /// <summary>
        /// 本地资源
        /// </summary>
        Local=1,
        /// <summary>
        /// 网络资源
        /// </summary>
        Network =2
    }

    public enum FileType //文件类型枚举
    {   /// <summary>
        /// 音乐
        /// </summary>
        Music = 1,
        /// <summary>
        /// 影片
        /// </summary>
        Movie = 2
    }

}
