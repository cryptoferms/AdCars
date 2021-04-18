using AdCars.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            //Preferences.Set("currentTime",(int)UnixTime)
            return true;
        }
    }
}
