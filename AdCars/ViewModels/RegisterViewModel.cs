using Acr.UserDialogs;
using AdCars.Services;
using AdCars.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdCars.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region propriedades de binding da RegisterView
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; OnPropertyChanged(); }
        }
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
        private bool _isBusy;
        public bool isBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }
        private bool _Result;
        public bool Result
        {
            get { return _Result; }
            set { _Result = value; OnPropertyChanged(); }
        }
        #endregion
        public Command VoltarCommand { get; set; }
        public Command RegistrarCommand { get; set; }

        public RegisterViewModel()
        {
            RegistrarCommand = new Command(async () => await RegistrarCommandAsync());
            VoltarCommand = new Command(async () => await VoltarCommandAsync());
        }

        private async Task RegistrarCommandAsync()
        {
            if (isBusy)
                return;
            try
            {
                using (UserDialogs.Instance.Loading(title: "Carregando..."))
                {
                    isBusy = true;
                    Result = await ApiService.RegistroUsuarios(Nome, Email, Senha);
                    if (Result)
                    {
                        await Application.Current.MainPage.DisplayAlert("BEM VINDO", "Sua conta foi criada com sucesso!", "OK");
                        await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("ERRO", "Não foi possível efetuar o registro, tente novamente mais tarde.", "OK");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                isBusy = false;
            }
        }

        private async Task VoltarCommandAsync()
        {
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }
    } 
}
