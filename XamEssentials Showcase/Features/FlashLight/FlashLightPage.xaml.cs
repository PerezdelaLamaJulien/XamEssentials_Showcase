using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.FlashLight;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashLightPage : ContentPage
    {
        public FlashLightPage()
        {
            InitializeComponent();
            BindingContext = new FlashLightPageVM();
        }
    }
}