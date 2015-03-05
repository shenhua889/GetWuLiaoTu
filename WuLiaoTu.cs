using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
namespace GetWuLiaoTu
{
    class WuLiaoTu
    {
        public void GetImgFile(string htmlStream)
        {
            string sRegex = "(?<=<img src=\")http[s]?:.[^ ]*\\.\\w{3,4}|(?<=org_src=\")http[s]?:.[^ ]*\\.\\w{3,4}";
            MatchCollection imgStrings = Regex.Matches(htmlStream, sRegex);
            StringBuilder s = new StringBuilder();
            foreach (Match m in imgStrings)
            {
                if (m.ToString().IndexOf("sinaimg.cn") != -1 && m.ToString().IndexOf("sinaimg.cn/thumbnail/")==-1)
                {
                    s.Append(m.ToString()+"\r\n");
                }
            }
            LoadFile("c:\\2.txt", s.ToString());
        }
        private void LoadFile(string fileString, string s)
        {
            FileStream file = new FileStream(fileString, FileMode.Create);
            using (StreamWriter sWrite = new StreamWriter(file))
            {
                sWrite.Write(s);
            }

        }
    }
}
