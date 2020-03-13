using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;

namespace BotYoutube.Manager.AccYoutube
{
    public partial class UpdateAccYoutube : FormUpdate
    {
        public UpdateAccYoutube()
        {
            InitializeComponent();
        }
        public override IEntityModel GetDataNew()
        {
            return new AccYoutubeModel();
        }
        public override void AfterLoad()
        {
            if (this.Model != null) {
                //txtUser.Enabled = false;
            }
        }
    }
}
