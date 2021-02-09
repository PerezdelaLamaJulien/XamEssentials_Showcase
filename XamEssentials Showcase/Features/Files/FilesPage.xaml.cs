using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Files;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilesPage : ContentPage
    {
        public FilesPage()
        {
            InitializeComponent();
            BindingContext = new FilesPageVM();
        }
    }
}