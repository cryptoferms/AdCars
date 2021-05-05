using AdCars.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnixTimeStamp;
using Xamarin.Essentials;

namespace AdCars.Services
{
    public static class ApiService
    {
        //instancia de http client de forma statica para ser utilizada nos métodos para recebimento da API
        private static HttpClient httpClient = new HttpClient();

        public static async Task<bool> RegistroUsuarios(string nome, string email, string senha)
        {
            var cadastro = new RegistroModel()
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };
            var json = JsonConvert.SerializeObject(cadastro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //método que irá fazer a requisição post para nossa API
            var resposta = await httpClient.PostAsync(AppSettings.ApiUrl + "api/contas/registro", content);
            if (!resposta.IsSuccessStatusCode)
                return false;
            else
                return true;
        }
        public static async Task<bool> Login(string email, string senha)
        {
            var login = new LoginModel()
            {
                Email = email,
                Senha = senha
            };
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //método que irá fazer a requisição post para nossa API
            var resposta = await httpClient.PostAsync(AppSettings.ApiUrl + "api/contas/login", content);
            if (!resposta.IsSuccessStatusCode) return false;
            var jsonResult = await resposta.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("userId", result.user_id);
            Preferences.Set("userNome", result.user_nome);
            Preferences.Set("userEmail", result.user_email);
            Preferences.Set("tokenExpirationTime", result.expiration_Time);
            Preferences.Set("currentTime", (int)UnixTime.GetCurrentTime());
            return true;
        }
        public static async Task<bool> TrocarSenha(string senhaAntiga, string novaSenha, string confirmarSenha)
        {
            var trocarsenha = new TrocarSenhaModel()
            {
                SenhaAntiga = senhaAntiga,
                NovaSenha = novaSenha,
                ConfirmarSenha = confirmarSenha
            };
            var json = JsonConvert.SerializeObject(trocarsenha);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.PostAsync(AppSettings.ApiUrl + "api/contas/trocarsenha", content);
            if (!resposta.IsSuccessStatusCode) return false;
            return true;
        }
        public static async Task<bool> EditarNumeroTelefone(string telefone)
        {
            await TokenValidator.CheckTokenValidade();
            var content = new StringContent($"Numero={telefone}", Encoding.UTF8, "application/x-www-form-urlencoded");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.PostAsync(AppSettings.ApiUrl + "api/contas/trocarsenha", content);
            if (!resposta.IsSuccessStatusCode) return false;
            return true;
        }
        public static async Task<bool> EditarFotoPerfil(byte[] imageArray)
        {
            await TokenValidator.CheckTokenValidade();
            var json = JsonConvert.SerializeObject(imageArray);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.PostAsync(AppSettings.ApiUrl + "api/contas/editarperfil", content);
            if (!resposta.IsSuccessStatusCode) return false;
            return true;
        }
        public static async Task<UserImageModel> GetUserImage()
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/contas/UserProfileImage");
            return JsonConvert.DeserializeObject<UserImageModel>(resposta);
        }
        public static async Task<CategoriaModel> GetCategorias()
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/categorias");
            return JsonConvert.DeserializeObject<CategoriaModel>(resposta);
        }
        public static async Task<bool> AddImage (int veiculoId, byte[] imageArray)
        {
            var ImageVeiculo = new VeiculoImageModel()
            {
                VeiculoId = veiculoId,
                ImageArray = imageArray
            };
            await TokenValidator.CheckTokenValidade();
            var json = JsonConvert.SerializeObject(ImageVeiculo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            return true;
        }
        public static async Task<VeiculoDetalhe> GetVeiculosDetalhe(int id)
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + $"api/veiculos/DetalhesVeiculos?=id{id}");
            return JsonConvert.DeserializeObject<VeiculoDetalhe>(resposta);
        }

        public static async Task<List<VeiculosPorCategoria>> GetVeiculosPorCategorias(int categoriaId)
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + $"api/veiculos?categoriaId={categoriaId}");
            return JsonConvert.DeserializeObject<List<VeiculosPorCategoria>>(resposta);
        }

        public static async Task<List<BuscarVeiculo>> BuscarVeiculos(string busca)
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + $"api/veiculos/BuscarVeiculos?busca={busca}");
            return JsonConvert.DeserializeObject<List<BuscarVeiculo>>(resposta);
        }
        public static async Task<VeiculoReponse> AddVeiculo(Veiculos veiculos)
        {
            var json = JsonConvert.SerializeObject(veiculos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Veiculos", content);
            var jsonResult = await resposta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VeiculoReponse>(jsonResult);
        }
        public static async Task<List<NovosRecomendadosAd>> GetNovosRecomendadosAds()
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/veiculos/NovosRecomendados");
            return JsonConvert.DeserializeObject<List<NovosRecomendadosAd>>(resposta);
        }

        public static async Task<List<MeusAds>> GetMeusAds()
        {
            await TokenValidator.CheckTokenValidade();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));
            var resposta = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/veiculos/MeusAds");
            return JsonConvert.DeserializeObject<List<MeusAds>>(resposta);
        }




        public static class TokenValidator
        {
            public static async Task CheckTokenValidade()
            {
                var expirationTime = Preferences.Get("tokenExpirationTime", 0);
                Preferences.Set("currentTime", (int)UnixTime.GetCurrentTime());
                var currentTime = Preferences.Get("currentTime", 0);
                if (expirationTime < currentTime)
                {
                    var email = Preferences.Get("email", string.Empty);
                    var senha = Preferences.Get("password", string.Empty);
                    await ApiService.Login(email, senha);
                }
            }
        }
    }
}