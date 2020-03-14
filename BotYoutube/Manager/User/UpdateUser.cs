using BotYoutube.Database;
using BotYoutube.Entities;
using BotYoutube.UI;
using System.Windows.Forms;

namespace BotYoutube.Manager.User
{
    public partial class UpdateUser : FormUpdate
    {
         public UserService service;
        public UpdateUser()
        {
            InitializeComponent();
        }
        public override IEntityModel GetDataNew()
        {
            return new UserModel();
        }
        public override bool BeforeSave()
        {
            if (Model == null&& service.CheckExitsUser(txtUser.Text)) {
                MessageBox.Show("User is exits.");
                return false;
            }
            
          return  base.BeforeSave();
        }
        public override bool AfterLoad()
        {
            if (this.Model != null) {
                txtUser.Enabled = false;
            }
            return base.AfterLoad();
        }
    }
}
