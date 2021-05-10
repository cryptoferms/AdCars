using AdCars.Models;
using AdCars.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreView : ContentPage
    {
        public ExploreView()
        {
            InitializeComponent();
            //nome.Text = Preferences.Get("userInfo", string.Empty);
        }

        private void CvVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecaoAtual = e.CurrentSelection.FirstOrDefault() as NovosRecomendadosAd;
            if (selecaoAtual == null) return;
            //Navigation.PushModalAsync(new ItemDetailPage)


        }
    }
}