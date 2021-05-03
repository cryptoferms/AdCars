using System;
using System.Collections.Generic;
using System.Text;
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

        }
    }
}
