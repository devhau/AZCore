using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.UI.Controls
{
    public class BCheckBox : CheckBox, IInput
    {
        public object GetValue()
        {
            return this.Checked;
        }

        public void SetValue(object obj)
        {
            this.Checked =(bool)obj;
        }
    }
}
