using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Metrics;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MetricsPage : ContentPage
    {
        public MetricsPage()
        {
            InitializeComponent();
            BindingContext = new MetricsPageVM();
        }
    }
}