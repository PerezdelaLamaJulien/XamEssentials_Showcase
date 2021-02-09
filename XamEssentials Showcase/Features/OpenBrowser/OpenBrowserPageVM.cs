using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.OpenBrowser
{
    public class OpenBrowserPageVM : BasePageViewModel
    {
        public ICommand OpenBrowserCommand { get; set; }
        public string Link { get; set; }

        public OpenBrowserPageVM()
        {
            OpenBrowserCommand = new Command(OpenBrowserAction);
        }

        private async void OpenBrowserAction(object obj)
        {
            Uri uri;

            try
            {
                if (!String.IsNullOrEmpty(Link))
                    uri = new Uri(Link);
                else
                    uri = new Uri("https://www.google.fr");

                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
