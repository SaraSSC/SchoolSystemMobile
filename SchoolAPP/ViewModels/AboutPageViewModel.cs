using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolAPP.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AboutPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Logo = "ic_icon_logabout.png";
            Information = "Application made by:\n" + "SaraSSC\n" + "Version 1.0";
        }

        public string Logo { get; set; }
        public string Information { get; set; }
    }
}
