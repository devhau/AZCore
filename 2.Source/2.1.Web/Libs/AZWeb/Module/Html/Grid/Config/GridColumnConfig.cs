using System;

namespace AZWeb.Module.Html.Grid
{
    public class GridColumnConfig
    {
        public String Name { get; set; }
        public Boolean Hidden { get; set; }

        public GridColumnConfig()
        {
            Name = "";
        }
    }
}
