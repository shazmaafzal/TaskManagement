using System.Text.Json;

namespace TaskManagement.InfraStructure
{
    public class ExternalPostService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExternalPostService> _logger;

        public ExternalPostService(HttpClient httpClient, ILogger<ExternalPostService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<object>> GetPostsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<object>>(content)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching external posts");
                return Enumerable.Empty<object>();
            }
        }
    }
}
