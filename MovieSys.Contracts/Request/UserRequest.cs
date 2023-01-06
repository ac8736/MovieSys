namespace MovieSys.Contracts.Movie;

public record UserRequest(
    string Email,
    string Username,
    string Password
);