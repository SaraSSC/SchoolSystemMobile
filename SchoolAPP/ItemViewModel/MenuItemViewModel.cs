using Prism.Commands;
using Prism.Navigation;
using SchoolAPP.Models;
using SchoolAPP.ViewModels;
using SchoolAPP.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAPP.ItemViewModel
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ??
            (_selectMenuCommand = new DelegateCommand(SelectMenuAsync));

        private async void SelectMenuAsync()
        {
            if (IsLoginRequired)
            {
                var mainViewModel = MainViewModel.GetInstance();

                if (mainViewModel.Token == null)
                {
                    await _navigationService.NavigateAsync
                        ($"/{nameof(SchoolSystemDetailPage)}/NavigationPage/{nameof(LoginPage)}");
                }

                if (mainViewModel.IsTokenValid())
                {
                    await _navigationService.NavigateAsync
                        ($"/{nameof(SchoolSystemDetailPage)}/NavigationPage/{PageName}");
                }
            }
            else
            {
                await _navigationService.NavigateAsync
                    ($"/{nameof(SchoolSystemDetailPage)}/NavigationPage/{nameof(AboutPage)}");
            }
        }
    }
}
