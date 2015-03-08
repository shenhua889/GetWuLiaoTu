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
            Images image = new Images();
            WuLiaoTu wuliaotu = new WuLiaoTu();
            for(int i=6100;i<6111;i++)
            {
                Console.WriteLine("开始抓取第{0}页无聊图", i);
                string htmlStream = wuliaotu.WuLiaoTuHtml(i);
                if (htmlStream == "失败")
                {
                    i--;
                    Console.WriteLine("第{0}页无聊图抓取网页失败,重新抓取",i);
                }
                else
                {
                    Console.WriteLine("第{0}页无聊图抓取成功,开始抓取图片",i);
                    image.GetImgFile(htmlStream, i.ToString());
                    Console.WriteLine("第{0}页无聊图抓取成功",i);
                }
            }
            //WebRequest request = WebRequest.Create("http://jandan.net/pic/page-6103#comments");
            //WebResponse response = request.GetResponse();
            //Console.WriteLine("获取页面");
            //StreamReader sRead = new StreamReader(response.GetResponseStream());
            //StringBuilder s=new StringBuilder();
            //Console.WriteLine("读取页面");
            //s.Append(sRead.ReadToEnd());
            //sRead.Close();
            //image.GetImgFile(s.ToString(),"6103");
            //FileStream file = new FileStream("c:\\1.txt", FileMode.Create);
            //using (StreamWriter sWrite = new StreamWriter(file))
            //{
            //    Console.WriteLine("写入页面");
            //    sWrite.Write(s);
            //}
            //Console.WriteLine("写入完成");
            //Console.ReadKey();
        }
    }
}
