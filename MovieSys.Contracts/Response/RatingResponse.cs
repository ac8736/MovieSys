namespace MovieSys.Contracts.Movie;

public record RatingResponse(
    Guid UserId,
    int Rate,
    string Comment
);