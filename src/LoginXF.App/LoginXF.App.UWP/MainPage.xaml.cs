using LoginXF.App.Ioc;
using LoginXF.App.UWP.Implementations;
using Prism;
using Prism.Ioc;

namespace LoginXF.App.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new LoginXF.App.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISqLiteConnection, SqLiteConnection>();
        }
    }
}
