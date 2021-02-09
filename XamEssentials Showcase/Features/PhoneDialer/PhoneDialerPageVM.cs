using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.PhoneDialer
{
    public class PhoneDialerPageVM : BasePageViewModel
    {
        public string Number { get; set; }
        public ICommand CallNumberCommand { get; set; }

        public PhoneDialerPageVM()
        {
            CallNumberCommand = new Command(CallNumberAction);
        }

        private void CallNumberAction(object obj)
        {
            if (!String.IsNullOrEmpty(Number))
            {
                try
                {
                    Xamarin.Essentials.PhoneDialer.Open(Number);
                }
                catch (FeatureNotSupportedException ex)
                {
                    ShowError(ex.Message);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }
    }
}
