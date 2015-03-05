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
            WuLiaoTu wuliaotu = new WuLiaoTu();
            WebRequest request = WebRequest.Create("http://jandan.net/pic/page-6103#comments");
            WebResponse response = request.GetResponse();
            Console.WriteLine("获取页面");
            StreamReader sRead = new StreamReader(response.GetResponseStream());
            StringBuilder s=new StringBuilder();
            Console.WriteLine("读取页面");
            s.Append(sRead.ReadToEnd());
            sRead.Close();
            wuliaotu.GetImgFile(s.ToString());
            FileStream file = new FileStream("c:\\1.txt", FileMode.Create);
            using (StreamWriter sWrite = new StreamWriter(file))
            {
                Console.WriteLine("写入页面");
                sWrite.Write(s);
            }
            Console.WriteLine("写入完成");
            Console.ReadKey();
        }
    }
}
