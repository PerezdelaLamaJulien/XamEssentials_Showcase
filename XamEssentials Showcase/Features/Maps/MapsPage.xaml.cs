using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEssentials_Showcase.Features.Maps;

namespace XamEssentials_Showcase.Features.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {

        public MapsPage()
        {
            InitializeComponent();
            BindingContext = new MapsPageVM();
        }
    }
}