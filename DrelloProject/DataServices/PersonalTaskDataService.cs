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
    public class PersonalTaskDataService : IPersonalTaskDataSevice
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAdress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public PersonalTaskDataService()
        {
            _httpClient = new HttpClient();
            _baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5017" : "https://localhost:7005";
            _url = $"{_baseAdress}/API/User";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<bool> AddPesonalTask(PersonalTask task, int userId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;
            try
            {
                string jsonContent = JsonSerializer.Serialize<PersonalTask>(task, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_url}/{userId}/AddPersonalTask", content);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption" + ex.Message);
                return false;
            }
            return false;
        }

        public async Task<bool> DeletePersonalTask(int personalTaskId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;
            try
            {
                var response = await _httpClient.DeleteAsync($"{_url}/DeletePersonalTask/{personalTaskId}");
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption" + ex.Message);
                return false;
            }
        }

        public async Task<ObservableCollection<PersonalTask>> GetPersonalTasks(int userId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;
            try
            {
                var response = await _httpClient.GetAsync($"{_url}/{userId}/GetPersonalTasks");
                if (response.IsSuccessStatusCode)
                {
                    var tasks = await response.Content.ReadFromJsonAsync<ObservableCollection<PersonalTask>>();
                    return tasks;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Oppa, exeption" + ex.Message);
                return null;
            }
        }
    }
}
