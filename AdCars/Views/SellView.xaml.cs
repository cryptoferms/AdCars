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
    public partial class SellView : ContentPage
    {
        public ObservableCollection<CategoriaModel> categoriasCollection;
        private int categoriaId;
        private string condicao;
        private string portas;
        private string cambio;
        private string direcao;
        public SellView()
        {
            InitializeComponent();
            categoriasCollection = new ObservableCollection<CategoriaModel>();
            GetVeiculosCategoria();
        }

        private async void GetVeiculosCategoria()
        {
            var categoriasApi = await ApiService.GetCategorias();
            foreach (var categoria in categoriasApi)
            {
                categoriasCollection.Add(categoria);
            }
            PickerCategory.ItemsSource = categoriasCollection;
        }

        private async void BtnSell_Clicked(object sender, EventArgs e)
        {
            var veiculo = new Veiculos()
            {
                Nome = EntNome.Text,
                Preco = Convert.ToInt32(EntPreco.Text),
                motor = EntMotor.Text,
                Localizacao = EntLocalizacao.Text,
                Modelo = EntModel.Text,
                Cor = EntCor.Text,
                Cambio = cambio,
                Direcao = direcao,
                Quilometragem = EntQuilometragem.Text,
                Ano = Convert.ToInt32(EntAno.Text),
                Portas = portas,
                Fabricante = EntFabricante.Text,
                Descricao = EdiDescription.Text,
                UsuarioId = Preferences.Get("userId", 0),
                CategoriaId = categoriaId,
                Condicao = condicao,
                Combustivel = EntCombustível.Text,
            };

            var resposta = await ApiService.AddVeiculo(veiculo);
            if (resposta == null) return;
            var veiculoId = resposta.veiculoId;
            await Navigation.PushModalAsync(new AddImageView(veiculoId));
        }

        private void PickerCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var categoriaSelecionada = (CategoriaModel)picker.SelectedItem;
            categoriaId = categoriaSelecionada.id;
        }

        private void TapUsed_Tapped(object sender, EventArgs e)
        {
            condicao = "Usado";
            FrameUsed.BackgroundColor = Color.FromHex("#303F9F");
            LblUsado.TextColor = Color.White;
            FrameNew.BackgroundColor = Color.White;
            LblNovo.TextColor = Color.FromHex("#303F9F");
        }

        private void TapNew_Tapped(object sender, EventArgs e)
        {
            condicao = "Novo";
            FrameNew.BackgroundColor = Color.FromHex("#303F9F");
            LblNovo.TextColor = Color.White;
            FrameUsed.BackgroundColor = Color.White;
            LblUsado.TextColor = Color.FromHex("#303F9F");
        }

        private void PickerPortas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var portaselecionada = picker.SelectedItem;
            portas = (string)portaselecionada;
        }

        private void PickerCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var cambioSelecionado = picker.SelectedItem;
            cambio = (string)cambioSelecionado;
        }

        private void pickerDirecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var direcaoSelecionada = picker.SelectedItem;
            direcao = (string)direcaoSelecionada;
        }
    }
}