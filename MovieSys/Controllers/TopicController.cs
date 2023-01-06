using MovieSys.Controllers;
using MovieSys.Services.Topics;
using Microsoft.AspNetCore.Mvc;
using MovieSys.Contracts.Movie;
using MovieSys.Models;

public class TopicController : ApiController
{
    private readonly ITopicService _topic;
    public TopicController(IConfiguration configuration, ITopicService topic) : base(configuration)
        => _topic = topic;

    [HttpPost]
    public IActionResult CreateTopic(TopicRequest request)
    {
        if (_topic.FindTopic(request, _configuration["ConnectionStrings:Default"]))
            return BadRequest(new Dictionary<string, string>() { { "status", "Topic already created." } });
        var topic = new Topic(request.MovieId, request.Topic);
        _topic.CreateTopic(topic, _configuration["ConnectionStrings:Default"]);
        var response = new TopicResponse(topic.TopicName);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetTopics(string id)
    {
        var result = _topic.GetAllTopic(id, _configuration["ConnectionStrings:Default"]);
        if (result.Count == 0)
            return NotFound();
        return Ok(new Dictionary<string, List<TopicResponse>>() { { "topics", result } });
    }

    [HttpDelete]
    public IActionResult DeleteTopic(TopicRequest request)
    {
        if (!_topic.FindTopic(request, _configuration["ConnectionStrings:Default"]))
            return NotFound();
        _topic.DeleteTopic(request, _configuration["ConnectionStrings:Default"]);
        return NoContent();
    }
}