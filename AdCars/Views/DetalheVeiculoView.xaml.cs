using AdCars.Services;
using System.Collections.ObjectModel;
using AdCars.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheVeiculoView : ContentPage
    {
        public ObservableCollection<Images> ImagemVeiculo;
        public DetalheVeiculoView(int id)
        {
            InitializeComponent();
            ImagemVeiculo = new ObservableCollection<Images>();
            GetDetalhesVeiculos(id);
        }

        private async void GetDetalhesVeiculos(int id)
        {
            var veiculo = await ApiService.GetVeiculosDetalhe(id);
            LblNome.Text = veiculo.nome;
            LblLocation.Text = veiculo.localizacao;
            LblCondicao.Text = veiculo.condicao;
            LblPreco.Text = veiculo.preco.ToString();
            LblFabricante.Text = veiculo.fabricante;
            LblDescricao.Text = veiculo.descricao;
            LblMotor.Text = veiculo.motor;
            LblModelo.Text = veiculo.modelo;
            LblCor.Text = veiculo.cor;
            var images = veiculo.images;
            foreach (var img in images)
            {
                ImagemVeiculo.Add(img);
            }
            CrvImages.ItemsSource = ImagemVeiculo;
        }
    }
}