namespace MovieSys.Contracts.Movie;

public record RatingRequest(
    Guid MovieId,
    Guid UserId,
    int Rating,
    string Comment
);