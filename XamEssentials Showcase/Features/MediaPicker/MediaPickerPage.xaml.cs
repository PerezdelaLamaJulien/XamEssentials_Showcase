using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.MediaPicker;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPickerPage : ContentPage
    {
        public MediaPickerPage()
        {
            InitializeComponent();
            BindingContext = new MediaPickerVM();
        }
    }
}