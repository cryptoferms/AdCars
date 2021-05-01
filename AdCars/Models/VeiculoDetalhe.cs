using System;
using System.Collections.Generic;
using System.Text;

namespace AdCars.Models
{
    public class VeiculoDetalhe
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int preco { get; set; }
        public string modelo { get; set; }
        public string fabricante { get; set; }
        public string motor { get; set; }
        public string cor { get; set; }
        public DateTime dataPostagem { get; set; }
        public string condicao { get; set; }
        public bool isNovo { get; set; }
        public bool isDestaque { get; set; }
        public string localizacao { get; set; }
        public List<Image> images { get; set; }
        public string email { get; set; }
        public string contato { get; set; }
        public string imageUrl { get; set; }
    }
    public class Image
    {
        public int id { get; set; }
        public string imageUrl { get; set; }
        public int veiculoId { get; set; }
        public object imageArray { get; set; }
    }
}
