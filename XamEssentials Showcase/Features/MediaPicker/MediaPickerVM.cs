using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.MediaPicker
{
    public class MediaPickerVM : BasePageViewModel
    {
        public ICommand TakePhotoCommand { get; set; }
        public ICommand GetPhotoCommand { get; set; }

        private string photoPath { get; set; }
        public string PhotoPath { get; set; }
        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged();
            }
        }

        public MediaPickerVM()
        {
            TakePhotoCommand = new Command(TakePhotoAction);
            GetPhotoCommand = new Command(GetPhotoAction);
        }

        private async void TakePhotoAction(object obj)
        {
            try
            {
                var photo = await Xamarin.Essentials.MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private async void GetPhotoAction(object obj)
        {
            try
            {
                var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
            ImageSource = ImageSource.FromFile(PhotoPath);
        }
    }
}
