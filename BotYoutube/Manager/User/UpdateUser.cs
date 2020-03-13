using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;

namespace BotYoutube.Manager.User
{
    public partial class UpdateUser : FormUpdate
    {
        public UpdateUser()
        {
            InitializeComponent();
        }
        public override IEntityModel GetDataNew()
        {
            return new UserModel();
        }
        public override void AfterLoad()
        {
            if (this.Model != null) {
                txtUser.Enabled = false;
            }
        }
    }
}
