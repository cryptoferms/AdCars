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
    public class LoginViewModel : BaseViewModel
    {
        #region PROPRIEDADES DE BINDING DA LOGINVIEW
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
        public Command LoginCommand { get; set; }
        public Command NavegadarRegistroCommand { get; set; }

        public LoginViewModel()
        {
            NavegadarRegistroCommand = new Command(async () => await RegisterCommandAsync());
            LoginCommand = new Command(async () => await LoginCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterView());
        }
        //MÉTODO PARA REALIZAR A LÓGICA DE LOGIN... AINDA NÃO IMPLEMENTADO
        private async Task LoginCommandAsync()
        {
            if (isBusy)
                return;
            try
            {
                using (UserDialogs.Instance.Loading(title: "Carregando..."))
                {
                    isBusy = true;
                    Result = await ApiService.Login(Email, Senha);
                    if (Result)
                    {
                        //lógica para navegar para a página inicial do App
                        Application.Current.MainPage = new NavigationPage(new HomeView());
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("AVISO", "Não foi possível efetuar o login", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", $"O seguinte erro ocorreu: {ex.Message}", "OK");
            }
            finally
            {
                isBusy = false;
            }
        }
    }
}
