using BotYoutube.Database;
using BotYoutube.Database.Attr;
using System;
using System.Data;

namespace BotYoutube.Entities
{
    [TableInfo(TableName = "bot_campaign")]
    public class CampaignModel : EntityModel<CampaignModel, long>
    {
        [Field]
        public DateTime StartCampaign { get; set; }
        [Field]
        public DateTime EndCampaign { get; set; }
        [Field]
        public long LinkId { get; set; }

    }
    public class CampaignService : EntityService<CampaignService, CampaignModel>
    {
        public CampaignService(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
