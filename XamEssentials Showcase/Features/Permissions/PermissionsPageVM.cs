using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Permissions
{
    public class PermissionsPageVM : BasePageViewModel
    {
        public List<string> PermissionNames { get; set; }
        public string SelectedPermission { get; set; }
        private string permissionState;
        public string PermissionState
        {
            get { return permissionState; }
            set
            {
                permissionState = value;
                RaisePropertyChanged();
            }
        }
        public ICommand CheckStatusCommand { get; set; }
        public ICommand AskPermissionCommand { get; set; }

        public PermissionsPageVM()
        {
            PermissionNames = new List<string>()
            {
                "LaunchApp",
                "ContactsRead",
                "Reminders",
                "StorageWrite",
            };
            PermissionState = "En Attente...";
            CheckStatusCommand = new Command(CheckStatusAction);
            AskPermissionCommand = new Command(AskPermissionAction);
        }
        private async void CheckStatusAction(object obj)
        {
            Xamarin.Essentials.PermissionStatus status;
            switch (SelectedPermission)
            {
                case "LaunchApp":
                    status = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.LaunchApp>();
                    break;
                case "ContactsRead":
                    status = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.ContactsRead>();
                    break;
                case "Reminders":
                    status = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.Reminders>();
                    break;
                case "StorageWrite":
                default:
                    status = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.StorageWrite>();
                    break;
            }

            PermissionState = "Permission " + status.ToString();
        }

        private async void AskPermissionAction(object obj)
        {
            Xamarin.Essentials.PermissionStatus status;

            switch (SelectedPermission)
            {
                case "LaunchApp":
                    status = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.LaunchApp>();
                    break;
                case "ContactsRead":
                    status = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.ContactsRead>();
                    break;
                case "Reminders":
                    status = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.Reminders>();
                    break;
                case "StorageWrite":
                default:
                    status = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.StorageWrite>();
                    break;
            }

            PermissionState = "Permission " + status.ToString();
        }
    }
}
