namespace MovieSys.Contracts.Movie;

public record TopicRequest(
    Guid MovieId,
    string Topic
);