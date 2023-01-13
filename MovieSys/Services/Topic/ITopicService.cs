using MovieSys.Contracts.Movie;
using MovieSys.Models;

namespace MovieSys.Services;

public interface ITopicService
{
    public void CreateTopic(Topic topic, string? connectionString);
    public List<TopicResponse> GetAllTopic(string id, string? connectionString);
    public void DeleteTopic(TopicRequest request, string? connectionString);
    public bool FindTopic(TopicRequest request, string? connectionString);
}