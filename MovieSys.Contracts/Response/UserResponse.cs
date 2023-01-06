namespace MovieSys.Contracts.Movie;

public record UserResponse(
    Guid Id,
    string Email,
    string Username
);