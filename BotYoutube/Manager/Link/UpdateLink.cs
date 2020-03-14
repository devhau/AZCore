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
    }
}
