using AdCars.Services;
using System.Collections.ObjectModel;
using AdCars.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheVeiculoView : ContentPage
    {
        public ObservableCollection<Images> ImagemVeiculo;
        private int totalimages;
        private string contato;
        private string email;
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
            LblPreco.Text = $"R${veiculo.preco.ToString()}";
            LblFabricante.Text = veiculo.fabricante;
            LblDescricao.Text = veiculo.descricao;
            LblMotor.Text = veiculo.motor;
            LblModelo.Text = veiculo.modelo;
            LblCor.Text = veiculo.cor;
            lblCambio.Text = veiculo.cambio;
            lblQuilometragem.Text = veiculo.quilometragem;
            lblAno.Text = veiculo.ano.ToString();
            lblCombustivel.Text = veiculo.combustivel;
            lblDirecao.Text = veiculo.direcao;
            LblDataPostagem.Text = $"Publicado em {veiculo.dataPostagem.ToString()}";
            lblPortas.Text = veiculo.portas;
            ImgUser.Source = veiculo.FullImageUrl;
            var images = veiculo.images;
            totalimages = veiculo.images.Count;
            contato = veiculo.contato;
            email = veiculo.email;
            foreach (var img in images)
            {
                ImagemVeiculo.Add(img);
            }
            CrvImages.ItemsSource = ImagemVeiculo;
        }

        private void CrvImages_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex <= totalimages)
            {
                var count = e.FirstVisibleItemIndex + 1;
                LblCount.Text = $"{count} de {totalimages}";
            }
        }

        private void BtnEmail_Clicked(object sender, System.EventArgs e)
        {
            var emailMessage = new EmailMessage("Pergunta sobre o Veículo no AdCars","Prezado, estou entrando em contato pois tenho interesse no seu veículo", email);
            Email.ComposeAsync(emailMessage);
        }

        private void BtnCall_Clicked(object sender, System.EventArgs e)
        {
            PhoneDialer.Open(contato);
        }

        private void BtnSms_Clicked(object sender, System.EventArgs e)
        {
            var smsMessage = new SmsMessage("Olá gostaria de ter mais informações sobre esse veículo", contato);
            Sms.ComposeAsync(smsMessage);
        }

        private async void BtnBack_Clicked(object sender, System.EventArgs e)
        {
           await Navigation.PopModalAsync();
        }
    }
}