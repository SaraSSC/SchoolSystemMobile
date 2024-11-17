using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SchoolAPP.ItemViewModel;
using SchoolAPP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolAPP.ViewModels
{
    public class SchoolSystemDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public SchoolSystemDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Models.Menu> menus = new List<Models.Menu>
            {
                new Models.Menu
                {
                    Icon = "ic_icon_myprofile.png",
                    PageName = $"{nameof(MyProfilePage)}",
                    Title = "My Profile",
                    IsLoginRequired = true
                },
                new Models.Menu
                {
                    Icon = "ic_icon_evaluations.png",
                    PageName = $"{nameof(MyEvaluationPage)}",
                    Title = "My Evaluations",
                    IsLoginRequired = true
                },
                new Models.Menu
                {
                    Icon = "ic_icon_about.png",
                    PageName = $"{nameof(AboutPage)}",
                    Title = "About",
                    IsLoginRequired = false
                }
            };

            var mainViewModel = MainViewModel.GetInstance();

            if (mainViewModel.IsTokenValid() && mainViewModel.IsEmailSaved())
            {
                var menuItem = new Models.Menu
                {
                    Icon = "ic_icon_logout.png",
                    PageName = $"{nameof(LogoutPage)}",
                    Title = "Logout",
                    IsLoginRequired = false
                };

                menus.Add(menuItem);
            }
            else
            {
                var menuItem = new Models.Menu
                {
                    Icon = "ic_icon_login.png",
                    PageName = $"{nameof(LoginPage)}",
                    Title = "Login",
                    IsLoginRequired = false
                };

                menus.Add(menuItem);
            }

            Menus = new ObservableCollection<MenuItemViewModel>
                (menus.Select(x => new MenuItemViewModel(_navigationService)
                {
                    Icon = x.Icon,
                    PageName = x.PageName,
                    Title = x.Title,
                    IsLoginRequired = x.IsLoginRequired
                }).ToList());
        }
    }
}
