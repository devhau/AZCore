using BotYoutube.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Tasks
{
    public class LoginGoogleTask : TaskBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginGoogleTask(BotBrowser _browser) : base(_browser)
        {
            this.Email = "kiemtienbn03@gmail.com";
            this.Password = "01644638697";
        }

        public override void DoTask()
        {
            UILog.AddLog("Start login : " + Email);
            Gecko.CookieManager.RemoveAll();
            this.Navigate("https://accounts.google.com/signin/v2/identifier?hl=vi&passive=true&continue=https%3A%2F%2Fwww.google.com%2Fwebhp%3Fhl%3Dvi%26sa%3DX%26ved%3D0ahUKEwjqwaG9kJToAhXXZt4KHeFwDxQQPAgH&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            this.WaitUtilDone();
            this.GetInputElement((t) => t.Name.ToLower().Equals("email")).DoTaskNotNull(p => p.Value = Email);
            this.GetInputElement((t) => t.Name.ToLower().Equals("signin")).DoTaskNotNull(p => p.Click());
            this.GetInputElement((t) => t.Name.ToLower().Equals("passwd")).DoTaskNotNull(p => p.Value = Password);
            this.GetInputElement((t) => t.Name.ToLower().Equals("signin")).DoTaskNotNull(p => p.Click());
            this.WaitUtilDone();
            UILog.AddLog("End login : " + Email);
        }
    }
}
