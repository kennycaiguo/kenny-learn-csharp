using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace csharpMediaPlayer
{
    public static class Common
    {
        //这个类用来读取App.config文件,可以获取一下公共消息,如项目名称,数据库配置等等
        public static string projectName = ConfigurationManager.AppSettings["projectName"];
    }
}
