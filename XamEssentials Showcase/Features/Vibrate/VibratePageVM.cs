using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Vibrate
{
    public class VibratePageVM : BasePageViewModel
    {
        public ICommand VibrateCommand { get; set; }
        public string VibrateSecondesString { get; set; }

        public VibratePageVM()
        {
            VibrateCommand = new Command(VibrateAction);
        }

        private void VibrateAction(object obj)
        {
            try
            {
                Int32.TryParse(VibrateSecondesString, out int vibrateSecondes);
                if (vibrateSecondes != 0)
                    Vibration.Vibrate(TimeSpan.FromSeconds(vibrateSecondes));
                else
                    Vibration.Vibrate();
            }
            catch (FeatureNotSupportedException)
            {
                ShowNotSupportedError();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
