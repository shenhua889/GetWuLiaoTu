using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
namespace GetWuLiaoTu
{
    class Images
    {
        public void GetImgFile(string htmlStream,string fileNum)
        {
            string imageDir = @"c:\" + fileNum;
            DecideFile(imageDir);
            string sRegex = "(?<=<img src=\")http[s]?:.[^ ]*\\.\\w{3,4}|(?<=org_src=\")http[s]?:.[^ ]*\\.\\w{3,4}";
            MatchCollection imgStrings = Regex.Matches(htmlStream, sRegex);
            StringBuilder s = new StringBuilder();
            foreach (Match m in imgStrings)
            {
                if (m.ToString().IndexOf("sinaimg.cn") != -1 && m.ToString().IndexOf("sinaimg.cn/thumbnail/")==-1)
                {
                    string imageURL = m.ToString();
                    string imageName = imageURL.Split('/').Last();
                    DownLoadImage(m.ToString(), imageDir+"\\"+imageName);
                }
            }
        }
        private void DecideFile(string filePath)
        {
            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }
        private void LoadFile(string fileString, string s)
        {
            FileStream file = new FileStream(fileString, FileMode.Create);
            using (StreamWriter sWrite = new StreamWriter(file))
            {
                sWrite.Write(s);
            }
        }
        private void DownLoadImage(string URL,string path)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(new Uri(URL), Path.Combine(path));
            }
            catch (Exception ex)
            {
                Console.WriteLine(URL+"\r\n"+ex.Message+"\r\n"+path);
            }
        }
    }
}
