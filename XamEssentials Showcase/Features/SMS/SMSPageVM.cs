using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.SMS
{
    public class SMSPageVM : BasePageViewModel
    {
        public string MessageText { get; set; }
        public string PhoneNumber { get; set; }

        public ICommand SendSmsCommand { get; set; }

        public SMSPageVM()
        {
            SendSmsCommand = new Command(SendSmsAction);
        }

        private async void SendSmsAction(object obj)
        {
            try
            {
                var message = new SmsMessage(MessageText, PhoneNumber);
                await Sms.ComposeAsync(message);
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
