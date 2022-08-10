using Nop.Core;
using Nop.Plugin.Misc.PersianCalendar.Infrastructure;
using Nop.Services.Common;
using Nop.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.PersianCalendar
{
    public class Plugin : BasePlugin, IMiscPlugin
    {
        #region Fields
        
        private readonly IWebHelper _webHelper;
       
        #endregion

        #region Ctor
      
        public Plugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + DefaultPlugin.GetConfigurationPageUrl;
        }
       
        #endregion

    }
}
