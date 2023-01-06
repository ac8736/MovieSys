namespace MovieSys.Models;

public class Movie
{
    public Guid Id { get; }
    public string Name { get; }
    public string Director { get; }
    public DateOnly Release { get; }
    public Movie(
        Guid id,
        string name,
        string director,
        DateOnly release)
    {
        Id = id;
        Name = name;
        Director = director;
        Release = release;
    }
}