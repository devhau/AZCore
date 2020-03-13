using System.Windows.Forms;

namespace BotYoutube.UI.Controls
{
    public class BNumericUpDown : NumericUpDown, IInput
    {
        public object GetValue()
        {
            return (int)this.Value;
        }
        public void SetValue(object obj)
        {
            this.Value = decimal.Parse(obj.ToString());
        }
    }
}
