﻿using DrelloProject.Models;
using System;
using System.Collections.Generic;
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
            {
                Debug.WriteLine("---> No internet access...");
            }

            try
            {
                string jsonContent = JsonSerializer.Serialize<Board>(board, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<Board>();
                    //Board responseBoard = JsonSerializer.Deserialize<Board>(apiResponse);
                    return apiResponse;
                }
                else
                {
                    Debug.WriteLine("Non Http 2xx response");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return null;
        }

        public Task<Board> GetBoard(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Board>> GetBoardsByUser(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}