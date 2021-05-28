using System.Collections.Generic;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Eren.Widgets.Slider
{
    public class ErenSliderPluginProcessor : BasePlugin, IWidgetPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Ctor

        public ErenSliderPluginProcessor(
            IWebHelper webHelper,
            ISettingService settingService,
            ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _settingService = settingService;
            _localizationService = localizationService;
        }
        #endregion
        
        #region overrides
        public override void Install()
        {
            var settings = new ErenSliderSettings
            {
                ContainerCssSelector = ".swiper-container",
                PaginationCssSelector = ".swiper-pagination",
                NavigationNextCssSelector = ".swiper-button-next",
                NavigationPrevCssSelector = ".swiper-button-prev",
                ScrollBarCssSelector = ".swiper-scrollbar",
                InitialSlide = 0,
                Speed = 300,
                Loop = true,
                NavigationEnabled = true,
                PaginationEnabled = true,
                ScroolBarEnabled = false
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.ContainerCssSelector", "Container Css Selector");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.PaginationCssSelector", "Sayfalama Css Selector");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.NavigationNextCssSelector", "Sonraki Sayfa Css Selector");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.NavigationPrevCssSelector", "Onceki sayfa Selector");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.ScrollBarCssSelector", "Gezinme cubugu Selector");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.InitialSlide", "Baslangic Slayti");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.Speed", "Gecis hizi");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.Loop", "Dongu");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.NavigationEnabled", "Yönlendirme aktif");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.PaginationEnabled", "Sayfalama aktif");
            _localizationService.AddOrUpdatePluginLocaleResource("Eren.Widgets.Slider.Models.ScroolBarEnabled", "Gezinme çubuğu aktif");

        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<ErenSliderSettings>();
            _localizationService.DeletePluginLocaleResource("Eren.Widgets.Slider");
        }

        public override void PreparePluginToUninstall()
        {
            base.PreparePluginToUninstall();
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ErenSlider/Configure";
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