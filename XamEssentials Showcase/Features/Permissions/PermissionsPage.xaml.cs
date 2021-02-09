using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Permissions;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermissionsPage : ContentPage
    {
        public PermissionsPage()
        {
            InitializeComponent();
            BindingContext = new PermissionsPageVM();
        }
    }
}