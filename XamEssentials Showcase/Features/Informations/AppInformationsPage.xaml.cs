using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Informations;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppInformationsPage : ContentPage
    {
        public AppInformationsPage()
        {
            InitializeComponent();
            BindingContext = new InformationsPageVM();
        }
    }
}