using NUnit.Framework;
using MovieSys.Services;
using MovieSys.Models;
using Microsoft.Extensions.Configuration;
using MovieSys.Contracts.Movie;

namespace MovieSys.Tests;

public class TopicServiceTest
{
    private readonly TopicService _topicService;
    private readonly IConfiguration _configuration;

    public TopicServiceTest()
    {
        _topicService = new TopicService();
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
    }

    [Test]
    public void FindTopic_Works()
    {
        TopicRequest request = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Sci-Fi");

        bool found = _topicService.FindTopic(request, _configuration["ConnectionStrings:Default"]);

        Assert.IsTrue(found);
    }

    [Test]
    public void GetAllTopic_Works()
    {
        string id = "9a2adc60-a772-4495-8290-d39e653a0228";
        List<TopicResponse> topics = new() { new TopicResponse("Sci-Fi") };

        List<TopicResponse> result = _topicService.GetAllTopic(id, _configuration["ConnectionStrings:Default"]);

        Assert.That(topics, Is.EqualTo(result));
    }

    [Test]
    public void CreateTopic_Works()
    {
        Topic topic = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Fantasy");

        _topicService.CreateTopic(topic, _configuration["ConnectionStrings:Default"]);
        bool found = _topicService.FindTopic(new TopicRequest(topic.MovieId, topic.TopicName), _configuration["ConnectionStrings:Default"]);

        Assert.IsTrue(found);
    }

    [Test]
    public void DeleteTopic_Work()
    {
        TopicRequest request = new(new Guid("9a2adc60-a772-4495-8290-d39e653a0228"), "Fantasy");

        _topicService.DeleteTopic(request, _configuration["ConnectionStrings:Default"]);
        bool found = _topicService.FindTopic(new TopicRequest(request.MovieId, request.Topic), _configuration["ConnectionStrings:Default"]);

        Assert.IsFalse(found);
    }
}