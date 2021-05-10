using AdCars.Services;
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
    public partial class DetalheVeiculoView : ContentPage
    {
        public DetalheVeiculoView(int id)
        {
            InitializeComponent();
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
        }
    }
}