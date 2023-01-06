namespace MovieSys.Contracts.Movie;

public record MovieResponse(
    Guid Id,
    string Name,
    string Director,
    DateOnly Release
);