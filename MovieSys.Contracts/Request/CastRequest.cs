namespace MovieSys.Contracts.Movie;

public record CastRequest
(
    Guid MovieID,
    string Actor,
    string Role
);