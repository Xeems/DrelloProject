using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAdress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        //https://localhost:7113
        //http://localhost:5115

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5115" : "https://localhost:7113";
            _url = $"{_baseAdress}/drello/API";

            _jsonSerializerOptions = new JsonSerializerOptions
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task AddUserAsync(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");                
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize<User>(user, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Users", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created User");
                    return;
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;

        }
    
        public async Task DeleteUserAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/Users/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created User");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        public async Task<User> GetUserAsync(User user)
        {

            if(Connectivity.Current.NetworkAccess !=NetworkAccess.Internet) 
            {
                Debug.WriteLine("No internet");
                return null;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Users/{user.Login}-{user.Password}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<User>(content, _jsonSerializerOptions);
                }   
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption"+ ex.Message);
            }
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize<User>(user, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/Users/{user.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created User");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }
    }
}
