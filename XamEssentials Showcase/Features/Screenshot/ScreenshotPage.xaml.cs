using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Screenshot;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScreenshotPage : ContentPage
    {
        public ScreenshotPage()
        {
            InitializeComponent();
            BindingContext = new ScreenshotPageVM();
        }
    }
}