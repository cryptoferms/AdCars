using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AdCars.Views;
using Xamarin.Essentials;

namespace AdCars.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(); }
        }
        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; OnPropertyChanged(); }
        }


        //commandos para metodos
        public Command UploadImageCommand { get; set; }

        public MyProfileViewModel()
        {
            UserInfo();
        }

        private void UserInfo()
        {
            Nome = Preferences.Get("userNome", string.Empty);
            Email = Preferences.Get("userEmail", string.Empty);
        }
    }
}
