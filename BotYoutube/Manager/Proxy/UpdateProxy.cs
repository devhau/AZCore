using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;

namespace BotYoutube.Manager.Proxy
{
    public partial class UpdateProxy : FormUpdate
    {
        public UpdateProxy()
        {
            InitializeComponent();
        }
        public override IEntityModel GetDataNew()
        {
            return new ProxyModel();
        }
      
    }
}
