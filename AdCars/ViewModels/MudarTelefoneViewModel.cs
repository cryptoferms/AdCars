using Acr.UserDialogs;
using AdCars.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdCars.ViewModels
{
    public class MudarTelefoneViewModel : BaseViewModel
    {
        private string _Telefone;
        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; OnPropertyChanged(); }
        }
        private bool _Result;

        public bool Result
        {
            get { return _Result; }
            set { _Result = value; OnPropertyChanged(); }
        }
        private bool _isBusy;

        public bool isBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }


        public Command AtualizarCommand { get; set; }

        public MudarTelefoneViewModel()
        {
            AtualizarCommand = new Command(async () => await AtualizarTelefoneAsync());
        }

        private async Task AtualizarTelefoneAsync()
        {
            if (isBusy)
                return;
            try
            {
                isBusy = true;
                Result = await ApiService.EditarNumeroTelefone(Telefone);
                if (!Result)
                {
                    await UserDialogs.Instance.AlertAsync("Alguma coisa deu errado, tente novamente mais tarde.", "AVISO", "OK", null);
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("Número de telefone atualizado com sucesso!", null, null);
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast($"ERROR {ex.Message}", TimeSpan.FromSeconds(2));
            }
            finally
            {
                isBusy = false;
            }
        }
    }
}
