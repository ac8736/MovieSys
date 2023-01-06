namespace MovieSys.Contracts.Movie;

public record MovieRequest(
    string Name,
    string Director,
    DateOnly Release
);