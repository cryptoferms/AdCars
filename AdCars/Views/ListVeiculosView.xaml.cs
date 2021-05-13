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
    public partial class ListVeiculosView : ContentPage
    {
        public ObservableCollection<VeiculosPorCategoria> veiculosPorCategorias;
        public ListVeiculosView(int categoriaId)
        {
            InitializeComponent();
            veiculosPorCategorias = new ObservableCollection<VeiculosPorCategoria>();
            GetVeiculos(categoriaId);
        }

        private async void GetVeiculos(int categoriaId)
        {
            var veiculos = await ApiService.GetVeiculosPorCategorias(categoriaId);
            foreach (var veiculo in veiculos)
            {
                veiculosPorCategorias.Add(veiculo);
            }
            LvVehicles.ItemsSource = veiculosPorCategorias;
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void LvVehicles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemselecionado = e.SelectedItem as VeiculosPorCategoria;
            Navigation.PushModalAsync(new DetalheVeiculoView(itemselecionado.id));
        }
    }
}