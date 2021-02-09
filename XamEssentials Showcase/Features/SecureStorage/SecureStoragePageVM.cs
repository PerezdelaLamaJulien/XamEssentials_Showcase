using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.SecureStorage
{
    public class SecureStoragePageVM : BasePageViewModel
    {
        public string AddedKey { get; set; }
        public string AddedValue { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private List<CustomData> customDatas;
        public List<CustomData> CustomDatas
        {
            get { return customDatas; }
            set
            {
                customDatas = value;
                RaisePropertyChanged();
            }
        }
        public CustomData SelectedData { get; set; }

        public SecureStoragePageVM()
        {
            CustomDatas = new List<CustomData>();
            CheckDatas();
            AddCommand = new Command(AddAction);
            DeleteCommand = new Command(DeleteAction);
        }

        private async void DeleteAction(object obj)
        {
            Xamarin.Essentials.SecureStorage.Remove(SelectedData.Key);

            string keysList = await Xamarin.Essentials.SecureStorage.GetAsync("savedKeys");
            List<string> Keys = keysList.Split('/').ToList();

            Keys.Remove(SelectedData.Key);
            string updatedKeysList = string.Join("/", Keys.ToArray());

            Xamarin.Essentials.SecureStorage.Remove("savedKeys");
            await Xamarin.Essentials.SecureStorage.SetAsync("savedKeys", updatedKeysList);
        }

        private async void CheckDatas()
        {
            string keysList = await Xamarin.Essentials.SecureStorage.GetAsync("savedKeys");
            if (keysList != null)
            {
                List<string> Keys = keysList.Split('/').ToList();

                foreach (string key in Keys)
                {
                    string value = await Xamarin.Essentials.SecureStorage.GetAsync(key);
                    CustomDatas.Add(new CustomData() { Key = key, Value = value });
                }
            }
        }

        private async void AddAction(object obj)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync(AddedKey, AddedValue);

            string keysList = await Xamarin.Essentials.SecureStorage.GetAsync("savedKeys");
            if (keysList != null)
            {
                keysList = keysList + "/" + AddedKey;
                Xamarin.Essentials.SecureStorage.Remove("savedKeys");
                await Xamarin.Essentials.SecureStorage.SetAsync("savedKeys", keysList);
            }
            else
                await Xamarin.Essentials.SecureStorage.SetAsync("savedKeys", AddedKey);
        }
    }

    public class CustomData
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
