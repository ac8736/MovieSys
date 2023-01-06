namespace MovieSys.Models;

public class Rating
{
    public Guid MovieId { get; }
    public Guid UserId { get; }
    public int Rate { get; }
    public string Comment { get; }

    public Rating(Guid movieId, Guid userId, int rate, string comment)
    {
        MovieId = movieId;
        UserId = userId;
        Rate = rate;
        Comment = comment;
    }
}