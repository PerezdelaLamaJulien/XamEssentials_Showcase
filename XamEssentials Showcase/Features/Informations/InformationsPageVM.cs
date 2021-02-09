using System.Globalization;
using Xamarin.Essentials;

namespace XamEssentials_Showcase.Features.Informations
{
    public class InformationsPageVM : BasePageViewModel
    {
        public string AppTheme { get; set; }
        public string AppName { get; set; }
        public string AppPackageName { get; set; }
        public string AppVersion { get; set; }
        public string AppBuild { get; set; }
        public string BatteryChargeLevel { get; set; }
        public string BatteryState { get; set; }

        public string NetworkAccess { get; set; }

        public string DeviceOrientation { get; set; }
        public string DeviceRotation { get; set; }
        public string DeviceWidth { get; set; }
        public string DeviceHeight { get; set; }
        public string DeviceScreenDensity { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceManufacturer { get; set; }
        public string DeviceName { get; set; }
        public string OSVersion { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }

        public string FirstLaunchEver { get; set; }
        

        public InformationsPageVM()
        {
            AppTheme = AppInfo.RequestedTheme.ToString();
            AppName = AppInfo.Name;
            AppPackageName = AppInfo.PackageName;
            AppVersion = AppInfo.VersionString;
            AppBuild = AppInfo.BuildString;
            BatteryState = Battery.State.ToString();

            if (Battery.ChargeLevel == 1)
                BatteryChargeLevel = "100%";
            else
                BatteryChargeLevel = Battery.ChargeLevel.ToString("#0.##%", CultureInfo.InvariantCulture);

            NetworkAccess = Connectivity.NetworkAccess.ToString();

            DeviceOrientation = DeviceDisplay.MainDisplayInfo.Orientation.ToString();
            DeviceRotation = DeviceDisplay.MainDisplayInfo.Rotation.ToString();
            DeviceWidth = DeviceDisplay.MainDisplayInfo.Width.ToString();
            DeviceHeight = DeviceDisplay.MainDisplayInfo.Height.ToString();
            DeviceScreenDensity = DeviceDisplay.MainDisplayInfo.Density.ToString();

            DeviceModel = DeviceInfo.Model;
            DeviceManufacturer = DeviceInfo.Manufacturer;
            DeviceName = DeviceInfo.Name;
            OSVersion = DeviceInfo.VersionString;
            Platform = DeviceInfo.Platform.ToString();
            Idiom = DeviceInfo.Idiom.ToString();

            FirstLaunchEver = VersionTracking.IsFirstLaunchEver.ToString();

        }
    }
}
