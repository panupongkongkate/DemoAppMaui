using DemoApp.Models;
using System.Text;
using System.Text.Json;

namespace DemoApp.DataServices
{
    public class RestDataServices : IRestDataServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataServices()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://171.96.120.53/" : "http://171.96.120.53/";
            _url = $"{_baseAddress}/api";
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task AddToDoAsync(Todo todo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("----> No Internet access");
                return;
            }
            try
            {
                string jsonTodo = JsonSerializer.Serialize<Todo>(todo);
                StringContent content = new StringContent(jsonTodo, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_baseAddress + "api/todo", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully Create Todo");
                }
                else
                {
                    Console.WriteLine("----> Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----> This Exception" + ex.Message);
            }
            return;
        }

        public async Task DeleteToDoAsync(string id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("----> No Internet access");
                return;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(_baseAddress + $"api/todo/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully Delete Todo");
                }
                else
                {
                    Console.WriteLine("----> Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----> This Exception" + ex.Message);
            }
            return;
        }

        public async Task<List<Todo>> GetAllToDoAsync()
        {
            List<Todo> todos = new List<Todo>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("----> No Internet access");
                return todos;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseAddress + "api/todo");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    todos = JsonSerializer.Deserialize<List<Todo>>(content);
                    return todos;
                }
                else
                {
                    Console.WriteLine("----> Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("----> This Exception" + ex.Message);
            }
            return todos;
        }

        public async Task UpdateToDoAsync(Todo todo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("----> No Internet access");
                return;
            }
            try
            {
                string jsonTodo = JsonSerializer.Serialize<Todo>(todo);
                StringContent content = new StringContent(jsonTodo, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(_baseAddress + $"api/todo/{todo._id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully Update Todo");
                }
                else
                {
                    Console.WriteLine("----> Non http 2xx response");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("----> This Exception" + ex.Message);
            }
            return;
        }
    }
}