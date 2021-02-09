using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Screenshot
{
    public class ScreenshotPageVM : BasePageViewModel
    {
        public ICommand ScreenShotCommand { get; set; }
        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged();
            }
        }

        public ScreenshotPageVM()
        {
            ScreenShotCommand = new Command(ScreenshotAction);
        }

        private async void ScreenshotAction(object obj)
        {
            var screenshot = await Xamarin.Essentials.Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            ImageSource = ImageSource.FromStream(() => stream);
        }
    }
}
