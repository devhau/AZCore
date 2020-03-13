using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.UI.Controls
{
    public interface IInput
    {
        void SetValue(object obj);
        object GetValue();
        
    }
}
