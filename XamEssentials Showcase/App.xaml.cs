using Xamarin.Essentials;
using Xamarin.Forms;
using XamEssentials_Showcase.Home;

namespace XamEssentials_Showcase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppActions.OnAppAction += AppActions_OnAppAction;

            Device.SetFlags(new string[] { "AppTheme_Experimental" });

            UserAppTheme = OSAppTheme.Dark;
            MainPage = new NavigationPage(new HomePage());
        }

        void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            // Don't handle events fired for old application instances
            // and cleanup the old instance's event handler
            if (Application.Current != this && Application.Current is App app)
            {
                AppActions.OnAppAction -= app.AppActions_OnAppAction;
                return;
            }
            //MainPage = new Page();
            MainPage.DisplayAlert("App Actions détectée", "L'action " + e.AppAction.Id + " a été détectée", "Ok", "Cancel");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
