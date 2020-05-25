using AZERP.Data.Enums;
using AZWeb.Module;
using AZWeb.Module.TagHelper;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-year-select")]
    public class YearSelect : AZSelect<YearSelect>
    {
        public int TimeYear{get;set;}
        protected override void InitData()
        {
            base.InitData();
            var yearNow=DateTime.Now.Year;
            this.Data = new System.Collections.Generic.List<ItemValue>();
            for (int year = yearNow - TimeYear; year <= yearNow + TimeYear; year++) {
                this.Data.Add( new ItemValue() { Value = year, Display = year.ToString() });
            }
        }
    }
}
