using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace GetWuLiaoTu
{
    class WuLiaoTu
    {
        string WuLiaoTuUrl = @"http://jandan.net/pic/page-{0}#comments";
        public string WuLiaoTuHtml(int HtmlNum)
        {
            try
            {
                string htmlStream = "";
                WebRequest request = WebRequest.Create(string.Format(WuLiaoTuUrl, HtmlNum));
                WebResponse response = request.GetResponse();
                StreamReader sRead = new StreamReader(response.GetResponseStream());
                htmlStream = sRead.ReadToEnd();
                return htmlStream;
            }
            catch
            {
                return "失败";
            }
        }
    }
}
