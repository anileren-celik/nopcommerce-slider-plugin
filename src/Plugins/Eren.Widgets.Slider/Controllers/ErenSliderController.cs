using System;
using Eren.Widgets.Slider.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Domain.Configuration;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Eren.Widgets.Slider.Controllers
{
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class ErenSliderController : BasePluginController
    {
        #region Fields

        private readonly ISettingService _settingService;
        private readonly ErenSliderSettings _erenSliderSettings;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;
        #endregion
        
        #region Ctor
        public ErenSliderController(
            ISettingService settingService, 
            ErenSliderSettings erenSliderSettings,
            INotificationService notificationService,
            ILocalizationService localizationService)
        {
            _settingService = settingService;
            _erenSliderSettings = erenSliderSettings;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }
        #endregion
        
        public IActionResult Configure()
        {
            var model = new ErenSliderConfigureModel
            {
                ContainerCssSelector = _erenSliderSettings.ContainerCssSelector,
                PaginationCssSelector = _erenSliderSettings.PaginationCssSelector,
                NavigationNextCssSelector = _erenSliderSettings.NavigationNextCssSelector,
                NavigationPrevCssSelector = _erenSliderSettings.NavigationPrevCssSelector,
                ScrollBarCssSelector = _erenSliderSettings.ScrollBarCssSelector,
                Direction = _erenSliderSettings.Direction,
                DirectionID = Convert.ToInt32(_erenSliderSettings.Direction),
                InitialSlide = _erenSliderSettings.InitialSlide,
                Speed = _erenSliderSettings.Speed,
                Loop = _erenSliderSettings.Loop,
                PaginationEnabled = _erenSliderSettings.PaginationEnabled,
                ScroolBarEnabled = _erenSliderSettings.ScroolBarEnabled
            };
            if (_erenSliderSettings.Direction == Direction.horizontal)
                model.Direction = Direction.horizontal;
            else
                model.Direction = Direction.vertical;
            return View("~/Plugins/Eren.Widgets.Slider/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ErenSliderConfigureModel model)
        {
            _erenSliderSettings.ContainerCssSelector = model.ContainerCssSelector;
            _erenSliderSettings.PaginationCssSelector = model.PaginationCssSelector;
            _erenSliderSettings.NavigationNextCssSelector = model.NavigationNextCssSelector;
            _erenSliderSettings.NavigationPrevCssSelector = model.NavigationPrevCssSelector;
            _erenSliderSettings.ScrollBarCssSelector = model.ScrollBarCssSelector;
            _erenSliderSettings.Direction = (Direction)Enum.Parse(typeof(Direction), model.DirectionID.ToString());
            _erenSliderSettings.InitialSlide = model.InitialSlide;
            _erenSliderSettings.Speed = model.Speed;
            _erenSliderSettings.Loop = model.Loop;
            _erenSliderSettings.PaginationEnabled = model.PaginationEnabled;
            _erenSliderSettings.ScroolBarEnabled = model.ScroolBarEnabled;
            
            _settingService.SaveSetting(_erenSliderSettings);
            _settingService.ClearCache();
            
            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            
            return Configure();

        }
    }
}