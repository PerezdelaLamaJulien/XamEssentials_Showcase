using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Share
{
    public class SharePageVM : BasePageViewModel
    {
        public string SharedText { get; set; }
        public ICommand ShareCommand { get; set; }

        public SharePageVM()
        {
            ShareCommand = new Command(ShareAction);
        }

        private async void ShareAction(object obj)
        {
            if (!String.IsNullOrEmpty(SharedText))
            {
                await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest
                {
                    Text = SharedText,
                    Title = "Share Text"
                });
            }
        }
    }
}
