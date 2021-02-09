using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Vibrate;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VibratePage : ContentPage
    {
        public VibratePage()
        {
            InitializeComponent();
            BindingContext = new VibratePageVM();
        }
    }
}