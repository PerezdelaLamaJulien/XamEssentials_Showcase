using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Email
{
    public class EmailPageVM : BasePageViewModel
    {
        public string MailAddress { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        public ICommand SendMailCommand { get; set; }

        public EmailPageVM()
        {
            SendMailCommand = new Command(SendMailAction);
        }

        private async  void SendMailAction(object obj)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(MailAddress))
                {
                    var message = new EmailMessage
                    {
                        Subject = "Ceci est un test",
                        Body = "Je viens de l'application XamEssentials Showcase!",
                        To = new List<string>() { "perezdelalama.julien@gmail.com" },
                    };
                    await Xamarin.Essentials.Email.ComposeAsync(message);
                }

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
