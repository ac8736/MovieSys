namespace MovieSys.Contracts.Movie;

public record WatchRequest(
    Guid MovieId,
    Guid UserId
);