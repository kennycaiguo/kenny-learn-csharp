using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace c_registrydemo
{
    internal class Program
    {
        static void CreateRegKey(RegistryKey key,string strSubKey,string valueKey,string value)
        {
            RegistryKey subKey = key.CreateSubKey(strSubKey);
            subKey.SetValue(valueKey, value);
            key.Close();
        }

        static void DeleteRegKey(RegistryKey key, string strSubKey)
        {
            key.DeleteSubKey(strSubKey);
            key.Close();
        }
        static void SetSubkeyValue(RegistryKey key, string strSubKey, string valueKey, string value)
        {
            RegistryKey subKey = key.OpenSubKey(strSubKey,true);
            subKey.SetValue(valueKey, value);
            key.Close();
        }
        static void Main(string[] args)
        {
            //CreateRegKey(Registry.CurrentUser, "Names", "name", "Tracy");
            //DeleteRegKey(Registry.CurrentUser, "Names");
            //SetSubkeyValue(Registry.CurrentUser, "Names", "name", "Bryan");//设置子键对应项的值
            CreateRegKey(Registry.CurrentUser, "Names", "pos", "Manager");//可以添加子键的子项
        }
    }
}
