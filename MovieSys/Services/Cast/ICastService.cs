using MovieSys.Contracts.Movie;
using MovieSys.Models;

namespace MovieSys.Services.Cast;

public interface ICastService
{
    public void CreateCast(Casts cast, string? connectionString);
    public List<CastResponse> GetAllCast(string? id, string? connectionString);
    public void DeleteCastMember(CastRequest request, string? connectionString);
    public bool FindCastMember(CastRequest request, string? connectionString);
}