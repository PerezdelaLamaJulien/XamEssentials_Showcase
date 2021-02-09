using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Contacts
{
    public class ContactsPageVM : BasePageViewModel
    {
        public ICommand GetContactCommand { get; set; }
        private string contactName;
        private string contactNumber;
        private string contactEmail;

        public string ContactName
        {
            get { return contactName; }
            set
            {
                contactName = value;
                RaisePropertyChanged();
            }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value;
                RaisePropertyChanged();
            }
        }
        public string ContactEmail
        {
            get { return contactEmail; }
            set
            {
                contactEmail = value;
                RaisePropertyChanged();
            }
        }

        public ContactsPageVM()
        {
            GetContactCommand = new Command(GetContactAction);
            ContactName = "Nom : En attente...";
            ContactNumber = "Numéro : En attente...";
            ContactEmail = "Email : En attente...";
        }

        private async void GetContactAction(object obj)
        {
            try
            {
                var contact = await Xamarin.Essentials.Contacts.PickContactAsync();

                if (contact == null)
                    return;

                ContactName = contact.Name;
                ContactNumber = contact.Numbers.FirstOrDefault().PhoneNumber;
                ContactEmail = contact.Emails.FirstOrDefault().EmailAddress;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
