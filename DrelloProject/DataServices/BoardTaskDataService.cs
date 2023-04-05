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
    public class BoardTaskDataService : IBoardTaskDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAdress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public BoardTaskDataService()
        {
            _httpClient = new HttpClient();
            _baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5017" : "https://localhost:7005";
            _url = $"{_baseAdress}/API/Tasks";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<ObservableCollection<ATask>> GetTasks(int BoardId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/GetTasks/{BoardId}");

                if (response.IsSuccessStatusCode)
                {
                    var tasks = await response.Content.ReadFromJsonAsync<ObservableCollection<ATask>>();
                    return tasks;
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }

            }
            catch (Exception ex)
            { Debug.WriteLine($"Whoops exception: {ex.Message}"); }

            return null;
        }
    }
}
