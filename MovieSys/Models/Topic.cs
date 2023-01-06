namespace MovieSys.Models;

public class Topic
{
    public Guid MovieId { get; }
    public string TopicName { get; }

    public Topic(Guid movieId, string topicName)
    {
        MovieId = movieId;
        TopicName = topicName;
    }
}