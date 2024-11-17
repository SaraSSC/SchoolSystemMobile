using Prism;
using Prism.Ioc;
using SchoolAPP.ViewModels;
using SchoolAPP.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace SchoolAPP
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXZcdHVTR2BeVkBzWUI=");

            await NavigationService.NavigateAsync($"NavigationPage/{nameof(LoginPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
           
            containerRegistry.RegisterForNavigation<LogoutPage, LogoutPageViewModel>();
           

            containerRegistry.RegisterForNavigation<SchoolSystemDetailPage, SchoolSystemDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MyProfilePage, MyProfilePageViewModel>();


            containerRegistry.RegisterForNavigation<MyEvaluationPage, MyEvaluationPageViewModel>();
            containerRegistry.RegisterForNavigation<MyEvaluationDetailsPage, MyEvaluationDetailsPageViewModel>();

            
        }
    }
}
