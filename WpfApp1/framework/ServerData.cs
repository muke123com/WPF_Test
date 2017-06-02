using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ServerData
    {
        public String GetServerData(String url)
        {
            String fileText = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            WebResponse res = req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            fileText = sr.ReadToEnd().ToString();
            
            return fileText;
        }
    }
}
