using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;

namespace BotYoutube.Manager.Bot
{
    public partial class UpdateBot : FormUpdate
    {
        public UpdateBot()
        {
            InitializeComponent();
        }
        public override IEntityModel GetDataNew()
        {
            return new LinkModel();
        }
        public override void AfterLoad()
        {
            if (this.Model != null) {
                //txtUser.Enabled = false;
            }
        }
    }
}
