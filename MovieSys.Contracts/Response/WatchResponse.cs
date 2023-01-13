namespace MovieSys.Contracts.Movie;

public record WatchResponse(
    Guid MovieId,
    Guid UserId
);