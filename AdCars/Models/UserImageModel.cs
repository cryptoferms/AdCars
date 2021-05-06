using AdCars.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdCars.Models
{
    public class UserImageModel
    {
        public string imageUrl { get; set; }
        public string FullImagePath => $"https://veiculosapi.conveyor.cloud/{imageUrl}";
    }
}
