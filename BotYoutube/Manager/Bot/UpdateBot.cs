﻿using BotYoutube.Database;
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
            return new BotModel();
        }
      
    }
}
