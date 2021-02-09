using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.DetectShake;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetectShakePage : ContentPage
    {
        DetectShakePageVM VM = new DetectShakePageVM();
        public DetectShakePage()
        {
            InitializeComponent();
            BindingContext = VM;
        }
    }
}