using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.TextToSpeech;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextToSpeechPage : ContentPage
    {
        public TextToSpeechPage()
        {
            InitializeComponent();
            BindingContext = new TextToSpeechPageVM();
        }
    }
}