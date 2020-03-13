using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.UI.Controls
{
     public class BDateTimePicker : DateTimePicker, IKeyCommand, IInput
    {
        public Keys KeyCommand { get ; set ; }

        public void DoCommand()
        {
            this.Focus();
        }

        public object GetValue()
        {
            return this.Value;
        }

        public void SetValue(object obj)
        {
            this.Value = (DateTime)obj;
        }
    }
}
