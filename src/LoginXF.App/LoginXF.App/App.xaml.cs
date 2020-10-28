using Prism;
using Prism.Ioc;
using LoginXF.App.ViewModels;
using LoginXF.App.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using LoginXF.App.Data;
using LoginXF.App.Services;

namespace LoginXF.App
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

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            //await NavigationService.NavigateAsync("NavigationPage/CreateUserPageViewModel");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            //Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateUserPage, CreateUserPageViewModel>();

            //Repositories
            containerRegistry.RegisterSingleton<IUserRepository, UserRepository>();

            //Services
            containerRegistry.RegisterSingleton<IUserTokenService, UserTokenService>();
        }
    }
}
