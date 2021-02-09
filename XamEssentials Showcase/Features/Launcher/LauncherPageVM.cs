using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Launcher
{
    public class LauncherPageVM : BasePageViewModel
    {
        public ICommand CheckSchemeCommand { get; set; }
        public string Scheme { get; set; }
        public LauncherPageVM()
        {
            CheckSchemeCommand = new Command(CheckSchemeAction);
        }

        private async void CheckSchemeAction(object obj)
        {
            string link;

            try
            {
                if (!String.IsNullOrEmpty(Scheme))
                    link = Scheme;
                else
                    link = "https://twitter.com/xamarinhq?s=09";

                bool supportsUri = await Xamarin.Essentials.Launcher.CanOpenAsync(link);

                if (supportsUri)
                    await Xamarin.Essentials.Launcher.OpenAsync(link);
                else
                    ShowError("Le lien n'est pas fonctionnel ");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
