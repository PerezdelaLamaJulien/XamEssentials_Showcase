using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.Preferences
{
    public class PreferencesPageVM : BasePageViewModel
    {
            public string AddedKey { get; set; }
            public string AddedValue { get; set; }
            public ICommand AddCommand { get; set; }
            public ICommand DeleteCommand { get; set; }

            private List<CustomPref> customPrefs;
            public List<CustomPref> CustomPrefs
            {
                get { return customPrefs; }
                set
                {
                    customPrefs = value;
                    RaisePropertyChanged();
                }
            }
            public CustomPref SelectedPref { get; set; }

            public PreferencesPageVM()
            {
                CustomPrefs = new List<CustomPref>();
                CheckPreferences();
                AddCommand = new Command(AddAction);
                DeleteCommand = new Command(DeleteAction);
            }

            private void DeleteAction(object obj)
            {
                Xamarin.Essentials.Preferences.Remove(SelectedPref.Key);

                string keysList = Xamarin.Essentials.Preferences.Get("savedKeys", "default_value");
                List<string> Keys = keysList.Split('/').ToList();

                Keys.Remove(SelectedPref.Key);
                string updatedKeysList = string.Join("/", Keys.ToArray());

                Xamarin.Essentials.Preferences.Remove("savedKeys");
                Xamarin.Essentials.Preferences.Set("savedKeys", updatedKeysList);
            }

            private void CheckPreferences()
            {
                bool hasKey = Xamarin.Essentials.Preferences.ContainsKey("savedKeys");
                if (hasKey)
                {
                    string keysList = Xamarin.Essentials.Preferences.Get("savedKeys", "default_value");
                    List<string> Keys = keysList.Split('/').ToList();

                    foreach (string key in Keys)
                    {
                        string value = Xamarin.Essentials.Preferences.Get(key, "default_value");
                        CustomPrefs.Add(new CustomPref() { Key = key, Value = value });
                    }
                }
            }

            private void AddAction(object obj)
            {
                Xamarin.Essentials.Preferences.Set(AddedKey, AddedValue);

                bool hasKey = Xamarin.Essentials.Preferences.ContainsKey("savedKeys");
                if (hasKey)
                {
                    string keysList = Xamarin.Essentials.Preferences.Get("savedKeys", "default_value");
                    keysList = keysList + "/" + AddedKey;
                    Xamarin.Essentials.Preferences.Remove("savedKeys");
                    Xamarin.Essentials.Preferences.Set("savedKeys", keysList);
                }
                else
                    Xamarin.Essentials.Preferences.Set("savedKeys", AddedKey);
            }
        }

        public class CustomPref
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
}
