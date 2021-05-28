using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Eren.Widgets.Slider.Components
{
    [ViewComponent(Name = "ErenSlider")]
    public class ErenSliderViewComponent : NopViewComponent 
    {
        #region Fields

        private readonly ErenSliderSettings _erenSliderSettings;
        #endregion

        #region Ctor

        public ErenSliderViewComponent(ErenSliderSettings erenSliderSettings)
        {
            _erenSliderSettings = erenSliderSettings;
        }

        #endregion
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            return View("~/Plugins/Eren.Widgets.Slider/Views/PublicInfo.cshtml", _erenSliderSettings);
        }
    }
}