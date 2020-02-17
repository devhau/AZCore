﻿using AZCore.Extensions;
using AZCore.Web.Configs;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public class ModulePortal
    {
        public Dictionary<string, ModuleBase> dicModule = new Dictionary<string, ModuleBase>();
        public string m { get; set; }
        public string v { get; set; }
        public string h { get; set; }
        public IHttpContextAccessor httpContext { get; set; }
        public IPagesConfig pageConfigs { get; set; }

        string AssemblyName { get; set; }
        public ModulePortal(IStartup startup, IHttpContextAccessor httpContext, IPagesConfig pageConfigs) {
            this.pageConfigs = pageConfigs;
            dicModule = startup.GetType().Assembly.GetTypes().Where(t => t.BaseType==typeof(ModuleBase)|| t.BaseType == typeof(ThemeBase)).Select((t)=>t.CreateInstance<ModuleBase>()).ToDictionary((t)=> t.GetType().FullName);
            AssemblyName = startup.AssemblyName;
            this.httpContext = httpContext;
        }
        public ThemeBase GetTheme()
        {
            string module = AssemblyName + ".Web.Themes."+this.pageConfigs.Theme+".LayoutTheme";          
            if (dicModule.ContainsKey(module)) return (ThemeBase)dicModule[module].InitModule(this.httpContext.HttpContext);
            var _module = module.CreateInstance<ThemeBase>(module);
            _module.InitModule(this.httpContext.HttpContext);
            dicModule.Add(module, _module);
            return _module;
        }
        public ModuleBase GetModule()
        {
           return  dicModule[this.httpContext.HttpContext.GetAssemblyName(AssemblyName)].InitModule(this.httpContext.HttpContext);
        }
        public IModuleResult GetResult()
        {
            return GetModule().GetResult();
        }
    }
}
