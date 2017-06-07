using System;
using System.IO;
using System.Text;

namespace WpfApp1
{
    class LocalData
    {
        /// <summary>
        /// 读取本地文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static String GetLocalData(String filePath)
        {
            String fileText;
            ///读取文件
            FileInfo file = new FileInfo(filePath);
            StreamReader sf = file.OpenText();
            fileText = sf.ReadLine();

            return fileText;
        }

        public static void WriteLocalData(String filePath, String fileText)
        {
            File.WriteAllText(filePath, fileText, Encoding.UTF8);
        }
    }
}
