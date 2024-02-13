using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinMediaPicker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GalleryPickerBtn_Clicked(object sender, EventArgs e)
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                return;
            }

            FileResult photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "Please select a photo"
            });

            var imageStream = await photo.OpenReadAsync();
            if (imageStream.Length == 0)
            {
                throw new ArgumentNullException(nameof(imageStream));
            }
            //return imageStream;

            //Display the photo in the image preview
            ImagePreview.Source = ImageSource.FromStream(() => imageStream);
        }

        private async void CameraCaptureBtn_Clicked(object sender, EventArgs e)
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                return;
            }

            FileResult photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "Take a picture"
            });

            var imageStream = await photo.OpenReadAsync();
            if (imageStream.Length == 0)
            {
                throw new ArgumentNullException(nameof(imageStream));
            }
            //return imageStream;

            ImagePreview.Source = ImageSource.FromStream(() => imageStream);
        }
    }
}
