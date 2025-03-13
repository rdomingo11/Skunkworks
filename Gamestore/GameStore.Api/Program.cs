using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStoreContext");

builder.Services.AddDbContextFactory<GameStoreContext>(options =>
    options.UseSqlServer(connString ?? throw new InvalidOperationException("Connection string 'GameStoreContext' not found.")));


var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

await app.MigrateDbAsync();

app.Run();
