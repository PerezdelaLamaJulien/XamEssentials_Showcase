using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamEssentials_Showcase.Features.Pages;

namespace XamEssentials_Showcase.Home
{
    public class HomePageVM : BasePageViewModel
    {
        public INavigation Navigation { get; set; }
        public List<Feature> Features { get; set; }

        public ICommand AboutCommand { get; set; }

        public HomePageVM(INavigation navigation)
        {
            Navigation = navigation;

            AboutCommand = new Command(() => Navigation.PushAsync(new InfoPage()));
            Features = new List<Feature>()
            {
                new Feature()
                {
                    Name = "App Actions",
                    TapCommand = new Command(() => Navigation.PushAsync(new AppActionsPage()))
                },
                new Feature()
                {
                    Name = "Contacts",
                    TapCommand = new Command(() => Navigation.PushAsync(new ContactsPage()))
                },
                new Feature()
                {
                    Name = "Detect Shake",
                    TapCommand = new Command(() => Navigation.PushAsync(new DetectShakePage()))
                },
                new Feature()
                {
                    Name = "Email",
                    TapCommand = new Command(() => Navigation.PushAsync(new EmailPage()))
                },
                new Feature()
                {
                    Name = "Files",
                    TapCommand = new Command(() => Navigation.PushAsync(new FilesPage()))
                },
                new Feature()
                {
                    Name = "FlashLight",
                    TapCommand = new Command(() => Navigation.PushAsync(new FlashLightPage()))
                },
                new Feature()
                {
                    Name = "Geolocation",
                    TapCommand = new Command(() => Navigation.PushAsync(new GeolocationPage()))
                },
                new Feature()
                {
                    Name = "Informations",
                    TapCommand = new Command(() => Navigation.PushAsync(new AppInformationsPage()))
                },
                new Feature()
                {
                    Name = "Launcher",
                    TapCommand = new Command(() => Navigation.PushAsync(new LauncherPage()))
                },
                new Feature()
                {
                    Name = "Maps",
                    TapCommand = new Command(() => Navigation.PushAsync(new MapsPage()))
                },
                new Feature()                            {
                    Name = "MediaPicker",
                    TapCommand = new Command(() => Navigation.PushAsync(new MediaPickerPage()))
                },
                new Feature()
                {
                    Name = "Metrics",
                    TapCommand = new Command(() => Navigation.PushAsync(new MetricsPage()))
                },
                new Feature()
                {
                    Name = "Open Browser",
                    TapCommand = new Command(() => Navigation.PushAsync(new OpenBrowserPage()))
                },
                new Feature()
                {
                    Name = "Permissions",
                    TapCommand = new Command(() => Navigation.PushAsync(new PermissionsPage()))
                },
                new Feature()
                {   
                    Name = "PhoneDialer",
                    TapCommand = new Command(() => Navigation.PushAsync(new PhoneDialerPage()))
                },
                new Feature()
                {
                    Name = "Preferences",
                    TapCommand = new Command(() => Navigation.PushAsync(new PreferencesPage()))
                },
                new Feature()
                {
                    Name = "Screenshot",
                    TapCommand = new Command(() => Navigation.PushAsync(new ScreenshotPage()))
                },
                new Feature()
                {
                    Name = "Secure Storage",
                    TapCommand = new Command(() => Navigation.PushAsync(new SecureStorage()))
                },
                new Feature()
                {
                    Name = "Share",
                    TapCommand = new Command(() => Navigation.PushAsync(new SharePage()))
                },
                new Feature()
                {
                    Name = "SMS",
                    TapCommand = new Command(() => Navigation.PushAsync(new SMSPage()))
                },
                new Feature()
                {
                    Name = "Text to Speech",
                    TapCommand = new Command(() => Navigation.PushAsync(new TextToSpeechPage()))
                },
                new Feature()
                {
                    Name = "Vibrate",
                    TapCommand = new Command(() => Navigation.PushAsync(new VibratePage()))
                }
            };
        }
    }
}
