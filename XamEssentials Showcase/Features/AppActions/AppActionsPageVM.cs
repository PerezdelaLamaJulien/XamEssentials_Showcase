using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.AppActions
{
    public class AppActionsPageVM : BasePageViewModel
    {
        public ICommand CreateCustomActionCommand { get; set; }
        public ICommand CreateDefaultActionCommand { get; set; }
        public string ActionText { get; set; }

        public AppActionsPageVM()
        {
            CreateCustomActionCommand = new Command(CreateCustomAction);
            CreateDefaultActionCommand = new Command(CreateDefaultAction);
        }

        private async void CreateDefaultAction(object obj)
        {
            try
            {
                await Xamarin.Essentials.AppActions.SetAsync(new AppAction("app_info", "App Info", icon: "app_info_action_icon"));
            }
            catch (FeatureNotSupportedException)
            {
                ShowNotSupportedError();
            }
        }

        private async void CreateCustomAction(object obj)
        {
            if (!String.IsNullOrWhiteSpace(ActionText))
            {

                try
                {
                    await Xamarin.Essentials.AppActions.SetAsync(new AppAction(ActionText, ActionText, subtitle: null, icon: "app_info_action_icon"));
                }
                catch (FeatureNotSupportedException)
                {
                    ShowNotSupportedError();
                }
            }
            else
            {
                ShowMessage("Texte manquant", "Veuillez écrire un texte dans l'entry pour continuer");
            }

        }
    }
}
