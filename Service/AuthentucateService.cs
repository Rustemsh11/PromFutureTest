using Contract;
using Entity;
using Newtonsoft.Json;

namespace Service
{
    public class AuthentucateService : IAuthenticateService
    {
        public async Task<User> Authenticate(AuthenticateModel authenticateModel)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient
                    .GetAsync($"{authenticateModel.Url}token?login={authenticateModel.Login}&password={authenticateModel.Password}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(apiResponse);
                    return user;
                }
            }
        }
    }
}
