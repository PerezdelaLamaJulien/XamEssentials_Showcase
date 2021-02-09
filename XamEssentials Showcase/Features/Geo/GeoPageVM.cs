using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Geo
{
    public class GeoPageVM : BasePageViewModel
    {
        public ICommand GetLocationCommand { get; set; }
        public ICommand GetLocationFromAdresseCommand { get; set; }

        private string locationLong;
        private string locationLat;
        private string locationAlt;

        public string LocationLong
        {
            get { return locationLong; }
            set
            {
                locationLong = value;
                RaisePropertyChanged();
            }
        }
        public string LocationLat
        {
            get { return locationLat; }
            set
            {
                locationLat = value;
                RaisePropertyChanged();
            }
        }
        public string LocationAlt
        {
            get { return locationAlt; }
            set
            {
                locationAlt = value;
                RaisePropertyChanged();
            }
        }
        public string GeoCodingAdresse { get; set; }

        public GeoPageVM()
        {
            GetLocationCommand = new Command(GetLocationAction);
            GetLocationFromAdresseCommand = new Command(GetLocationFromAdresseAction);

            LocationLong = "Longitude: En Attente...";
            LocationLat = "Latitude: En Attente...";
            LocationAlt = "Altitude: En Attente...";
        }

        private async void GetLocationFromAdresseAction(object obj)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(GeoCodingAdresse);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    LocationLong = "Longitude: " + location.Longitude.ToString();
                    LocationLat = "Latitude: " + location.Latitude.ToString();
                    LocationAlt = "Altitude: " + location.Altitude.ToString();
                }
            }
            catch (FeatureNotSupportedException )
            {
                ShowNotSupportedError();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private async void GetLocationAction(object obj)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    LocationLong = "Longitude: " + location.Longitude.ToString();
                    LocationLat = "Latitude: " + location.Latitude.ToString();
                    LocationAlt = "Altitude: " + location.Altitude.ToString();
                }
            }
            catch (FeatureNotSupportedException)
            {
                ShowNotSupportedError();
            }
            catch (FeatureNotEnabledException fneEx)
            {
                ShowError(fneEx.Message);
            }
            catch (PermissionException pEx)
            {
                ShowError(pEx.Message);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
