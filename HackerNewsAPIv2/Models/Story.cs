using Newtonsoft.Json;

namespace HackerNewsAPIv2.Models
{
    public class Story
    {
        public string Title { get; set; }
        public string Url { get; set; }
        [JsonProperty("by")]
        public string PostedBy { get; set; }
        public long Time { get; set;}
        public int Score { get; set;}
        public List<int> Kids { get; set; }

    }
}
