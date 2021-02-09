using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Geo;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeolocationPage : ContentPage
    {
        public GeolocationPage()
        {
            InitializeComponent();
            BindingContext = new GeoPageVM();
        }
    }
}