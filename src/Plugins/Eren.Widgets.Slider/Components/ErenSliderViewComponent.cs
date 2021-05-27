using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Eren.Widgets.Slider.Components
{
    [ViewComponent(Name = "ErenSlider")]
    public class ErenSliderViewComponent : NopViewComponent 
    {
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            return View("~/Plugins/Eren.Widgets.Slider/Views/PublicInfo.cshtml");
        }
    }
}