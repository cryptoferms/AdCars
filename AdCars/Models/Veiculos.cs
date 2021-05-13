using System;
using System.Collections.Generic;
using System.Text;

namespace AdCars.Models
{
    public class Veiculos
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public string Cor { get; set; }
        public string Fabricante { get; set; }
        public int Ano { get; set; }
        public string Cambio { get; set; }
        public string Direcao { get; set; }
        public string Portas { get; set; }
        public string Quilometragem { get; set; }
        public string Combustivel { get; set; }
        public string Condicao { get; set; }
        public string motor { get; set; }
        public int Preco { get; set; }
        public string Modelo { get; set; }
        public string Localizacao { get; set; }
    }
}
