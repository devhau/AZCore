using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;

namespace BotYoutube.Manager.Link
{
    public partial class UpdateLink : FormUpdate
    {
        public UpdateLink()
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
