using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Launcher;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LauncherPage : ContentPage
    {
        public LauncherPage()
        {
            InitializeComponent();
            BindingContext = new LauncherPageVM();
        }
    }
}