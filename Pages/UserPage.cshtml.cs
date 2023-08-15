using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Models;
using MotivWebApp.Services.Products;
using Newtonsoft.Json;

namespace MotivWebApp.Pages
{
    public class UserPageModel : PageModel
    {
        
        private readonly ProductRegistry _productRegistry;
        private readonly string _userApiUrl;

        public UserPageModel(ProductRegistry productRegistry, IConfiguration appSettings) 
        {
            _productRegistry = productRegistry;
            _userApiUrl = appSettings.GetValue<string>("UserApiUrl");
        }

        public User? CurrentUser { get; private set; } = null;

        public async Task OnGetAsync()
        {
            if (CurrentUser == null) {
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(_userApiUrl);
                dynamic? jsonData = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                if (jsonData != null) {
                    CurrentUser = new User(jsonData.results[0], _productRegistry.GetRandomProduct());
                }
            }
        }
    }
}