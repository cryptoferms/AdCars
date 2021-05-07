using AdCars.Services;
using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfileView : ContentPage
    {
        private MediaFile file;
        public MyProfileView()
        {
            InitializeComponent();
        }


        public async void PegarImagemGaleria()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", "Desculpe, seu dispositivo não suporta essa funcionalidade ", "OK");
                return;
            }

            file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            ProfileImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                AddImageToServer();
                return stream;
            });
        }
        //metodo para adicionar a imagem para o server
        private async void AddImageToServer()
        {
            var ImageArray = FromFile.ToArray(file.GetStream());
            file.Dispose();

            var resposta = await ApiService.EditarFotoPerfil(ImageArray);
            if (resposta) return;
            await DisplayAlert("Algo deu errado", "Por favor envie a foto novamente", "OK");
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var userprofileImage = await ApiService.GetUserImage();
            if (string.IsNullOrEmpty(userprofileImage.imageUrl))
                ProfileImage.Source = "userPlaceHolder.png";
            else
                ProfileImage.Source = userprofileImage.FullImagePath;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria();
        }
    }
}