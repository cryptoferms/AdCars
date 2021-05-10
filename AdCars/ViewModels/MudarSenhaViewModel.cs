using Acr.UserDialogs;
using AdCars.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdCars.ViewModels
{
    public class MudarSenhaViewModel : BaseViewModel
    {
        #region PROPRIEDADES DE BINDING 
        private string _SenhaAtual;
        public string SenhaAtual
        {
            get { return _SenhaAtual; }
            set { _SenhaAtual = value; OnPropertyChanged(); }
        }
        private string _NovaSenha;
        public string NovaSenha
        {
            get { return _NovaSenha; }
            set { _NovaSenha = value; OnPropertyChanged(); }
        }
        private string _ConfirmarSenha;
        public string ConfirmarSenha
        {
            get { return _ConfirmarSenha; }
            set { _ConfirmarSenha = value; OnPropertyChanged(); }
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

        //Commands
        public Command TrocarSenhaCommand { get; set; }
        public MudarSenhaViewModel()
        {
            TrocarSenhaCommand = new Command(async () => await TrocarSenhaAsync());
        }

        private async Task TrocarSenhaAsync()
        {
            if (isBusy)
                return;
            try
            {
                using (UserDialogs.Instance.Toast("Atualizando sua senha...", TimeSpan.FromSeconds(2)))
                {
                    isBusy = true;
                    Result = await ApiService.TrocarSenha(SenhaAtual, NovaSenha, ConfirmarSenha);

                    if (Result)
                        UserDialogs.Instance.Alert("Senha alterada com sucesso!", null, "OK");
                    else
                    {
                        UserDialogs.Instance.Alert("Não foi possível atualizar sua senha, tente novamente mais tarde.", null, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERRO", $"{ex.Message}","cancel");
            }
            finally
            {
                isBusy = false;
            }
        }
    }
}
