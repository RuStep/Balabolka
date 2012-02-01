using System;
using System.Windows.Forms;
using System.Drawing;

namespace Kontalka.Captcha
{
    internal sealed class CaptchaDialog : Captcha
    {
        private Form owner = null;

        public CaptchaDialog(Form owner)
        {
            this.owner = owner;
        }

        public override string RequestEnterCaptcha()
        {
            string url = String.Format("http://vk.com/captcha.php?s=1&sid={0}", this.sid);
            Image img = GetCaptcha(url);

            var form = new CaptchaForm(img);
            if (owner != null)
            {
                owner.Invoke((MethodInvoker) delegate { form.ShowDialog(owner); });
            }
            else
            {
                form.ShowDialog();
            }
            string result = form.enteredText;
            form.Dispose();

            return result;
        }
    }
}