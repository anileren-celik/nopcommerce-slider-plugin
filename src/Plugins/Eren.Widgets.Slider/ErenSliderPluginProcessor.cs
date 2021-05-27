using System.Collections.Generic;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Eren.Widgets.Slider
{
    public class ErenSliderPluginProcessor : BasePlugin, IWidgetPlugin
    {
        #region overrides
        public override void Install()
        {
            base.Install();
        }

        public override void Uninstall()
        {
            base.Uninstall();
        }

        public override void PreparePluginToUninstall()
        {
            base.PreparePluginToUninstall();
        }
        #endregion
        
        #region implements

        public bool HideInWidgetList => false;
        
        public IList<string> GetWidgetZones()
        {
            return new List<string> {PublicWidgetZones.HomepageTop, PublicWidgetZones.ProductDetailsTop };
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "ErenSlider";
        }
        #endregion

    }
}