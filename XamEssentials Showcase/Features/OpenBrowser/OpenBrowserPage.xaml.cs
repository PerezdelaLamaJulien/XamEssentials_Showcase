using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.OpenBrowser;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenBrowserPage : ContentPage
    {
        public OpenBrowserPage()
        {
            InitializeComponent();
            BindingContext = new OpenBrowserPageVM();
        }
    }
}