using Wordle.api.Services;
using Wordle.api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Change CORS policy here

string allowance = "AllowAll";

var allowAll = builder.Services.AddCors(options => {
    options.AddPolicy(allowance, builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILeaderboardService, LeaderboardServiceMemory>();

//Create a connection to the DB using a scoped resource
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Add a scope for ScoreStatsService in ASP.net core
builder.Services.AddScoped<ScoreStatsService>();

//Add a scope for ScoreStatsService in ASP.net core
builder.Services.AddScoped<PlayerService>();

//build the app
var app = builder.Build();

//Create a sccope to get the services in our app that was built
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    ScoreStatsService.Seed(context);
    PlayerService.Seed(context);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(allowance);

app.UseAuthorization();

app.MapControllers();

app.Run();
