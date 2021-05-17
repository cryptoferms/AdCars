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
    public partial class AddImageView : ContentPage
    {
        private MediaFile file;
        private int _veiculoId;
        public AddImageView(int veiculoId)
        {
            InitializeComponent();
            _veiculoId = veiculoId;
        }
        public async void PegarImagemGaleria(Image imageControl)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", "Desculpe, seu dispositivo não suporta essa funcionalidade ", "OK");
                return;
            }

            file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
            {
                CompressionQuality = 50,
                PhotoSize = PhotoSize.Large
            });

            if (file == null)
                return;

            imageControl.Source = ImageSource.FromStream(() =>
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

            var resposta = await ApiService.AddImage(_veiculoId, ImageArray);
            if (resposta) return;
            await DisplayAlert("Algo deu errado", "Por favor envie a foto novamente", "OK");
        }

        private void TapImg1_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria(Img1);
        }

        private void TapImg2_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria(Img2);
        }

        private void TapImg3_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria(Img3);
        }

        private void TapImg4_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria(Img4);
        }

        private void TapImg5_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria(Img5);
        }

        private void TapImg6_Tapped(object sender, EventArgs e)
        {
            PegarImagemGaleria(Img6);
        }

        private void BtnDone_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomeView());
            Navigation.RemovePage(this);
        }
    }
}