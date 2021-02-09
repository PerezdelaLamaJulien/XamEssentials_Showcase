using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.SMS;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMSPage : ContentPage
    {
        public SMSPage()
        {
            InitializeComponent();
            BindingContext = new SMSPageVM();
        }
    }
}