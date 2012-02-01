using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Drawing;

namespace Kontalka.Captcha
{
    public abstract class Captcha
    {
        public string sid { get; set; }

        public string SetSidFromPage(string page)
        {
            this.sid = ParseCaptcha(page);
            if (String.IsNullOrEmpty(sid))
            {
                throw new ApplicationException("Unxepected format for page");
            }
            return sid;
        }

        protected string ParseCaptcha(string page)
        {
            var k = new Regex("\"captcha_sid\":\"([0-9]*)\"", RegexOptions.Singleline);
            var match = k.Match(page);
            if (match.Success)
            {
                return match.Groups[1].ToString();
            }
            else
            {
                return null;
            }
        }

        public bool CheckNeedCaptcha(string page)
        {
            return ParseCaptcha(page) != null;
        }

        protected Image GetCaptcha(string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            var respose = request.GetResponse();
            var stream = respose.GetResponseStream();
            var image = Image.FromStream(stream);
            stream.Close();

            return image;
        }

        public virtual string RequestCaptchaAndGetPostParams(string page)
        {
            SetSidFromPage(page);
            return String.Format("&captcha_sid={0}&captcha_key={1}", this.sid, RequestEnterCaptcha());
        }

        public abstract string RequestEnterCaptcha();
    }
}