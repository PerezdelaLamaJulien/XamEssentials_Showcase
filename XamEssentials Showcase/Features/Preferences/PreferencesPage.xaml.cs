using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Preferences;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesPage : ContentPage
    {
        public PreferencesPage()
        {
            InitializeComponent();
            BindingContext = new PreferencesPageVM();
        }
    }
}