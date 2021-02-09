using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.AppActions;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppActionsPage : ContentPage
    {
        public AppActionsPage()
        {
            InitializeComponent();
            BindingContext = new AppActionsPageVM();
        }
    }
}