using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentials_Showcase.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            Title = "Xamarin Essentials Showcase";
            HomePageVM VM = new HomePageVM(Navigation);
            BindingContext = VM;
        }
    }
}