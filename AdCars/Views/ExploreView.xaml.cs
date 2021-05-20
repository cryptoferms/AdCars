using AdCars.Models;
using AdCars.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreView : ContentPage
    {
        public ObservableCollection<NovosRecomendadosAd> NovosRecomendadosCollection;
        public ExploreView()
        {
            InitializeComponent();
            NovosRecomendadosCollection = new ObservableCollection<NovosRecomendadosAd>();
            //nome.Text = Preferences.Get("userInfo", string.Empty);
            GetNovosRecomendadosAds();
        }

        private async void GetNovosRecomendadosAds()
        {
            var veiculos = await ApiService.GetNovosRecomendadosAds();
            // todo: ver dps se tem como pegar
            // sem a categoria-->
            // var veiculos = await ApiService.GetVeiculosPorCategorias();
            foreach (var veiculo in veiculos)
            {
                NovosRecomendadosCollection.Add(veiculo);
            }
            CvVeiculos.ItemsSource = NovosRecomendadosCollection;
        }
         
        private void CvVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecaoAtual = e.CurrentSelection.FirstOrDefault() as NovosRecomendadosAd;
            if (selecaoAtual == null) return;
            Navigation.PushModalAsync(new DetalheVeiculoView(selecaoAtual.id));


        }
    }
}