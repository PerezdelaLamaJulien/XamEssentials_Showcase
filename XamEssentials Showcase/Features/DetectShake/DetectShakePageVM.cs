using System;
using Xamarin.Essentials;

namespace XamEssentials_Showcase.Features.DetectShake
{
    public class DetectShakePageVM : BasePageViewModel
    {
        SensorSpeed speed = SensorSpeed.UI;
        private string shakeString;
        public string ShakeString
        {
            get { return shakeString; }
            set
            {
                shakeString = value;
                RaisePropertyChanged();
            }
        }
        private int ShakeCount;

        private bool switchIsToggled;
        public bool SwitchIsToggled
        {
            get { return switchIsToggled; }
            set
            {
                switchIsToggled = value;
                ToggleAccelerometer(switchIsToggled);
                RaisePropertyChanged();
            }
        }

        public DetectShakePageVM()
        {
            ShakeCount = 0;
            ShakeString = "Lancer la détection et secouer votre mobile";
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            ShakeCount++;
            ShakeString = "Vous avez secoué votre mobile " + ShakeCount.ToString() + " fois";
        }

        public void ToggleAccelerometer(bool isToggled)
        {
            try
            {
                if (isToggled)
                    Accelerometer.Start(speed);
                else
                    Accelerometer.Stop();

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
