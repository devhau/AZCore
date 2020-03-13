using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube.UI.Controls
{
    public  interface IKeyCommand
    {
        Keys KeyCommand { get; set; }
        void DoCommand();
    }
}
