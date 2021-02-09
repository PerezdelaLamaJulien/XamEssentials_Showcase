using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Email;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailPage : ContentPage
    {
        public EmailPage()
        {
            InitializeComponent();
            BindingContext = new EmailPageVM();
        }
    }
}