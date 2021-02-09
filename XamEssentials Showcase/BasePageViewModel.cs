using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamEssentials_Showcase
{
    public abstract class BasePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        public void ShowError(string text)
        {
            App.Current.MainPage.DisplayAlert("Erreur", text, "Ok");
        }

        public void ShowNotSupportedError()
        {
            App.Current.MainPage.DisplayAlert("Erreur", "La fonctionnalité n'est pas supportée", "Ok");
        }

        public void ShowMessage(string title, string text)
        {
            App.Current.MainPage.DisplayAlert(title, text, "Ok");
        }
    }
}
