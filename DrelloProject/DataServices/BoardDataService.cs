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
    public class BoardDataService : IBoardDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAdress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public BoardDataService()
        {
            _httpClient = new HttpClient();
            _baseAdress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5017" : "https://localhost:7005";
            _url = $"{_baseAdress}/API/Boards";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<Board> AddBoard(Board board)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                string jsonContent = JsonSerializer.Serialize<Board>(board, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<Board>();
                    return apiResponse;
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }

            }
            catch (Exception ex)
                { Debug.WriteLine($"Whoops exception: {ex.Message}");}

            return null;
        }

        public async Task<BoardRole> AddBoardRoles(ICollection<BoardRole> boardRoles, Board board)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");
            try
            {
                string jsonContent = JsonSerializer.Serialize(boardRoles, _jsonSerializerOptions);   
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/{board.Id}/AddRoles", content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<BoardRole>();
                    return apiResponse;
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }

            }
            catch (Exception ex) 
                { Debug.WriteLine($"Whoops exception: {ex.Message}");}

            return null;
        }

        public Task<Board> GetBoard(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Board>> GetBoardsByUser(int UserId)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{UserId}/GetBoardsByUser");

                if (response.IsSuccessStatusCode)
                {
                    var boards = await response.Content.ReadFromJsonAsync<ObservableCollection<Board>>();
                    return boards;
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
    
        public async Task<ObservableCollection<UserInBoard>> GetUsersInBoard(int BoardId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{BoardId}/GetUsersInBoard");

                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<ObservableCollection<UserInBoard>>();
                    return users;
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

        public async Task<bool> AddUserToBoard(int UserId, int BoardId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{BoardId}/AddUserToBoard/{UserId}");

                if (response.IsSuccessStatusCode)
                    return true;
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return false;
                }

            }
            catch (Exception ex)
            { Debug.WriteLine($"Whoops exception: {ex.Message}"); }

            return false;
        }

        public async Task<ObservableCollection<BoardRole>> GetRoles(int BoardId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{BoardId}/GetRoles");

                if (response.IsSuccessStatusCode)
                {
                    var roles = await response.Content.ReadFromJsonAsync<ObservableCollection<BoardRole>>();
                    return roles;
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

        public async Task<ObservableCollection<BoardRole>> AddRole(int boardId, BoardRole boardRole)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");

            try
            {
                string jsonContent = JsonSerializer.Serialize<BoardRole>(boardRole, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/{boardId}/AddRole", content);

                if (response.IsSuccessStatusCode)
                {
                    var roles = await response.Content.ReadFromJsonAsync<ObservableCollection<BoardRole>>();
                    return roles;
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

        public async Task<ObservableCollection<UserInBoard>> GiveRole(int BoardId, int UserInBoardId, int RoleId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                Debug.WriteLine("---> No internet access...");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/{BoardId}/{UserInBoardId}/GiveRole/{RoleId}");

                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<ObservableCollection<UserInBoard>>();
                    return users;
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

