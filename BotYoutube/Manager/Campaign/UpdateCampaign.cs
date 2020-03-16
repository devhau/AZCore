using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;

namespace BotYoutube.Manager.Campaign
{
    public partial class UpdateCampaign : FormUpdate
    {
        public UpdateCampaign()
        {
            InitializeComponent();
        }
        public override IEntityModel GetDataNew()
        {
            return new CampaignModel();
        }
    }
}
