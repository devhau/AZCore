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
    }
}
