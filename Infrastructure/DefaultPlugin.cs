using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.PersianCalendar.Infrastructure
{
    public static class DefaultPlugin
    {
        public static string SystemName => "Misc.PersianCalendar";
        public static string GetConfigurationPageUrl => $"Admin/{SystemName}/Configure";
        public static string PluginPath => "~/Plugins/" + SystemName;
        public static string ViewsPath => PluginPath + "/Views/";
        public static string ViewsJs => PluginPath + "/js/";
        public static string ViewsCss => PluginPath + "/css/persian-datepicker.min.css";

    }
}
