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
    public class CourseItemViewModel : CoursesReply
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCourseCommand;

        public CourseItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCourseCommand => _selectCourseCommand
            ?? (_selectCourseCommand = new DelegateCommand(OnSelectCourseAsync));


        private async void OnSelectCourseAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "course", this }
            };

            await _navigationService.NavigateAsync(nameof(MyEvaluationDetailsPage), parameters);
        }
    }
}
