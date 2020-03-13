using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.UI.Controls
{
    public class BTextbox : TextBox, IInput,IKeyCommand
    {
        public object GetValue()
        {
            return this.Text;
        }

        public void SetValue(object obj)
        {
            this.Text = obj == null ? "" : obj.ToString();
        }
        public Keys KeyCommand { get; set; }

        public void DoCommand()
        {
            this.Focus();
        }
    }
}
