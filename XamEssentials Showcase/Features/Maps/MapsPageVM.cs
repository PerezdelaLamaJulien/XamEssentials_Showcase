using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Maps
{
    public class MapsPageVM : BasePageViewModel
    {
        public ICommand OpenDefaultMapCommand { get; set; }
        public ICommand OpenMapWithPlaceMarkCommand { get; set; }

        public MapsPageVM()
        {
            OpenDefaultMapCommand = new Command(OpenDefaultMapAction);
            OpenMapWithPlaceMarkCommand = new Command(OpenMapWithPlaceMarkAction);
        }

        private async void OpenMapWithPlaceMarkAction(object obj)
        {
            var placemark = new Placemark
            {
                CountryName = "United States",
                AdminArea = "WA",
                Thoroughfare = "Microsoft Building 25",
                Locality = "Redmond"
            };
            var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            try
            {
                await Map.OpenAsync(placemark, options);
            }
            catch (Exception ex)
            {
                // No map application available to open or placemark can not be located
                ShowError(ex.Message);
            }
        }

        private async void OpenDefaultMapAction(object obj)
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open
                ShowError(ex.Message);
            }
        }
    }
}
