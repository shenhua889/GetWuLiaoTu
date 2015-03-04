using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace GetWuLiaoTu
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://jandan.net/pic/page-6097#comments");
            //request.Credentials = CredentialCache.DefaultCredentials;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebRequest request = WebRequest.Create("http://jandan.net/pic/page-6097#comments");
            WebResponse response = request.GetResponse();
            Console.WriteLine("获取页面");
            StreamReader sRead = new StreamReader(response.GetResponseStream());
            StringBuilder s=new StringBuilder();
            Console.WriteLine("读取页面");
            s.Append(sRead.ReadToEnd());
            sRead.Close();
            FileStream file = new FileStream("c:\\1.txt", FileMode.Create);
            file.Close();
            StreamWriter sWrite = new StreamWriter("c:\\1.txt");
            Console.WriteLine("写入页面");
            sWrite.Write(s);
            sWrite.Close();
            Console.WriteLine("写入完成");
            Console.ReadKey();
        }
    }
}
