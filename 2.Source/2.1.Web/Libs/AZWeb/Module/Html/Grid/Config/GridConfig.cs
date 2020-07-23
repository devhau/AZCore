using System;

namespace AZWeb.Module.Html.Grid
{
    public class GridConfig
    {
        public String Name { get; set; }
        public GridColumnConfig[] Columns { get; set; }

        public GridConfig()
        {
            Name = "";
            Columns = Array.Empty<GridColumnConfig>();
        }
    }
}
