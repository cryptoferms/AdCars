using System;
using System.Collections.Generic;
using System.Text;

namespace AdCars.Models
{
    public class MeusAds
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int preco { get; set; }
        public DateTime data { get; set; }
        public string localizacao { get; set; }
        public string fabricante { get; set; }
        public bool isDestaque { get; set; }
        public object imageUrl { get; set; }
        public string isDestaqueAd => isDestaque ? "Premium" : "Grátis";
        public string AdDataPostagem => data.ToString("y");
        public string FullImageURl => $"https://veiculosapi.conveyor.cloud/{imageUrl}";
    }
}
