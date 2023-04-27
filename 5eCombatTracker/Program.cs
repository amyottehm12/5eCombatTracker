using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.API.Services;
using _5eCombatTracker.Data;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Seeder;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>
    (options => options.UseNpgsql(builder.Configuration["5eCombatTracker"]));

builder.Services.AddScoped<IMonsterService, MonsterService>();
builder.Services.AddScoped<IDbSeeder, DbSeeder>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDbSeederMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
