using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Eren.Widgets.Slider.Models
{
    public class ErenSliderConfigureModel : BaseNopModel
    {
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.ContainerCssSelector")]
        public string ContainerCssSelector { get; set; }

        [NopResourceDisplayName("Eren.Widgets.Slider.Models.PaginationCssSelector")]
        public string PaginationCssSelector { get; set; }

        [NopResourceDisplayName("Eren.Widgets.Slider.Models.NavigationNextCssSelector")]
        public string NavigationNextCssSelector { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.NavigationPrevCssSelector")]
        public string NavigationPrevCssSelector { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.ScrollBarCssSelector")]
        public string ScrollBarCssSelector { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.Direction")]
        public int DirectionID { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.Direction")]
        public Direction Direction { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.InitialSlide")]
        public int InitialSlide { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.Speed")]
        public int Speed { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.Loop")]
        public bool Loop { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.NavigationEnabled")]
        public bool NavigationEnabled { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.PaginationEnabled")]
        public bool PaginationEnabled { get; set; }
        
        [NopResourceDisplayName("Eren.Widgets.Slider.Models.ScroolBarEnabled")]
        public bool ScroolBarEnabled { get; set; }

    }
}