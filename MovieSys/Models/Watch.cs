namespace MovieSys.Models;

public class Watch
{
    public Guid MovieId { get; }
    public Guid UserId { get; }

    public Watch(Guid movieId, Guid userId)
    {
        MovieId = movieId;
        UserId = userId;
    }
}