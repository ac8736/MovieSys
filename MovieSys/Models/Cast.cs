namespace MovieSys.Models;

public class Casts
{
    public Guid MovieId { get; }
    public string Actor { get; }
    public string Role { get; }
    public Casts(
        Guid movieID,
        string actor,
        string role)
    {
        MovieId = movieID;
        Actor = actor;
        Role = role;
    }
}