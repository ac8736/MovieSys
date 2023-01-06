using MovieSys.Services.Users;
using MovieSys.Services.Movies;
using MovieSys.Services.Cast;
using MovieSys.Services.Rate;
using MovieSys.Services.Topics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddScoped<ICastService, CastService>();
    builder.Services.AddScoped<IRateService, RateService>();
    builder.Services.AddScoped<ITopicService, TopicService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
