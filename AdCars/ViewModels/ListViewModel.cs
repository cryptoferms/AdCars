using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdCars.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public Command VoltarCommand { get; set; }
        public ListViewModel()
        {
            VoltarCommand = new Command(async () => await VoltarCommandAsync());
        }

        private async Task VoltarCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
