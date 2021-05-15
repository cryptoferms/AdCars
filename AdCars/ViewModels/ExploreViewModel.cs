using AdCars.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdCars.ViewModels
{
    public class ExploreViewModel : BaseViewModel
    {
        #region PROPRIEDADES DE BINDING DA EXPLOREVIEW
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(); }
        }
        private string _Senha;
        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; OnPropertyChanged(); }
        }
        #endregion

        //Commands para Navigation
        public Command TruckCommand { get; set; }
        public Command CarCommand { get; set; }
        public Command BikesCommand { get; set; }
        public Command PesquisaCommand { get; set; }


        public ExploreViewModel()
        {
            BikesCommand = new Command(async () => await NavegarBikesAsync());
            CarCommand = new Command(async () => await NavegarCarrosAsync());
            TruckCommand = new Command(async () => await NavegarCamionetesAsync());
            PesquisaCommand = new Command(async () => await PesquisarVeiculosAsync());
        }

        private async Task PesquisarVeiculosAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new BuscarVeiculoView());
        }

        private async Task NavegarCamionetesAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ListVeiculosView(3));
        }

        private async Task NavegarCarrosAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ListVeiculosView(2));
        }

        private async Task NavegarBikesAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ListVeiculosView(1));
        }
    }
}
