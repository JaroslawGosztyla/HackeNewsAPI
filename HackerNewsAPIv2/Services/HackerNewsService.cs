using HackerNewsAPIv2.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace HackerNewsAPIv2.Services
{
    public class HackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;

        public HackerNewsService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<IEnumerable<int>?> GetBestStoriesIDsAsync(CancellationToken cancellationToken = default)
        {
            var uri = new Uri("https://hacker-news.firebaseio.com/v0/beststories.json");
            return await _cache.GetOrCreateAsync("best_stories_ids", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20); 
                var response = await _httpClient.GetAsync(uri, cancellationToken); ;
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<List<int>>(json);
            });


        }

        public async Task<Story?> GetStoryAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _cache.GetOrCreateAsync($"story_details_{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20); 
                var response = await _httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{id}.json", cancellationToken);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<Story>(json);
            });
        }
    }
}
