using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.SecureStorage;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecureStorage : ContentPage
    {
        public SecureStorage()
        {
            InitializeComponent();
            BindingContext = new SecureStoragePageVM();
        }
    }
}