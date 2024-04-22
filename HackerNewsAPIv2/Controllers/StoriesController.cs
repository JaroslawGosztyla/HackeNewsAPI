using HackerNewsAPIv2.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAPIv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly HackerNewsService _newsService;

        public StoriesController(HackerNewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("{count}")]
        public async Task<IActionResult> GetBestStories(int count, CancellationToken cancellationToken)
        {
            var ids = await _newsService.GetBestStoriesIDsAsync(cancellationToken);
            var tasks = ids.Select(id => _newsService.GetStoryAsync(id, cancellationToken));
            var stories = await Task.WhenAll(tasks);

            var topStories = stories
                .Where(story => story != null) 
                .OrderByDescending(story => story.Score)
                .Take(count)
                .Select(story => new StoryDto
                {
                    Title = story.Title,
                    Uri = story.Url,
                    PostedBy = story.PostedBy,
                    Time = DateTimeOffset.FromUnixTimeSeconds(story.Time).DateTime,
                    Score = story.Score,
                    CommentCount = story.Kids?.Count ?? 0
                })
                .ToArray(); 

            return Ok(topStories);
        }

    }
}