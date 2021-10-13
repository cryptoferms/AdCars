using AdCars.Models;
using AdCars.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAds : ContentPage
    {
        public ObservableCollection<MeusAds> meusAdsColecao;
        public MyAds()
        {
            InitializeComponent();
            meusAdsColecao = new ObservableCollection<MeusAds>();
            GetVeiculos();
        }

        private async void GetVeiculos()
        {
            var veiculos = await ApiService.GetMeusAds();
            foreach (var veiculo in veiculos)
            {
                meusAdsColecao.Add(veiculo);
            }
            LvVehicles.ItemsSource = meusAdsColecao;
        }

        private async void LvVehicles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemselecionado = e.SelectedItem as MeusAds;
            if (itemselecionado == null) return;
            await Navigation.PushModalAsync(new DetalheVeiculoView(itemselecionado.id));
            ((ListView)sender).SelectedItem = null;
        }
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    var MeusAdsId = new MeusAds();
        //    var DeleteAds = new DeleteAds(MeusAdsId.id);
        //    DeleteAds.DeleteVeiculo(MeusAdsId.id);

        //}
    }
}