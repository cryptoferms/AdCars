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
    public partial class BuscarVeiculoView : ContentPage
    {
        public BuscarVeiculoView()
        {
            InitializeComponent();
        }

        private async void SearchBarVehicle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var veiculos = await ApiService.BuscarVeiculos(e.NewTextValue);
           
            LvSearch.ItemsSource = veiculos;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchBarVehicle.Focus();
        }

        private void LvSearch_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var veiculoSelecionado = e.SelectedItem as BuscarVeiculo;
            Navigation.PushModalAsync(new DetalheVeiculoView(veiculoSelecionado.id));
        }
    }
}