using DrelloProject.IDataService;
using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
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


        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5017" : "https://localhost:7005";
            _url = $"{_baseAdress}/API";

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

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/register", content);

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

        public async Task<ObservableCollection<User>> FindUsers(string userName)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet");
                return null;
            }
            try
            {
                var response = await _httpClient.GetAsync($"{_url}/User/FindUsers/{userName}");
                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<ObservableCollection<User>>();
                    return users;
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption" + ex.Message);
                return null;
            }
        }

        public async Task<User> GetCurrentUser(int userId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet");
                return null;
            }
            try
            {
                var response = await _httpClient.GetAsync($"{_url}/User/{userId}/GetCurrentUser");
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<User>();
                    return user;
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption" + ex.Message);
                return null;
            }
        }

        public async Task<User> GetUserAsync(User user)
        {
            string jsonUser = JsonSerializer.Serialize<User>(user, _jsonSerializerOptions);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            if (Connectivity.Current.NetworkAccess !=NetworkAccess.Internet) 
            {
                Debug.WriteLine("No internet");
                return null;
            }
            try
            {
                var response = await _httpClient.PostAsync($"{_url}/logIn", content);
                if (response.IsSuccessStatusCode)
                {
                    User currentUser = await response.Content.ReadFromJsonAsync<User>();
                    return currentUser;
                }   
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption"+ ex.Message);
                return null;
            }
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

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/Users/", content);

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
