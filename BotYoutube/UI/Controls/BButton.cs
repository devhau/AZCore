using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.UI.Controls
{
     public class BButton : Button, IKeyCommand
    {
        public Keys KeyCommand { get ; set ; }

        public void DoCommand()
        {
            this.PerformClick();
        }
    }
}
