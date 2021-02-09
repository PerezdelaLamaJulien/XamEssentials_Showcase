using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamEssentials_Showcase.Features.FlashLight
{
    public class FlashLightPageVM : BasePageViewModel
    {
        private bool switchIsToggled;
        public bool SwitchIsToggled
        {
            get { return switchIsToggled; }
            set
            {
                switchIsToggled = value;
                TurnOnOffFlashLight(switchIsToggled);
                RaisePropertyChanged();
            }
        }

        public FlashLightPageVM()
        {
            SwitchIsToggled = false;
        }

        public async void TurnOnOffFlashLight(bool isToggled)
        {
            try
            {
                if (isToggled)
                    await Flashlight.TurnOnAsync();
                else
                    await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException)
            {
                ShowNotSupportedError();
            }
            catch (PermissionException)
            {
                ShowError("Les Permissions n'ont pas été données");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
