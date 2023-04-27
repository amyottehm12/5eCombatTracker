using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.API.Services;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Seeder;
using _5eCombatTracker.Migrations;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var connectionString = builder.Configuration.GetConnectionString("5eCombatTracker");
builder.Services.AddLogging(x => x.AddFluentMigratorConsole())
    .AddFluentMigratorCore()
    .ConfigureRunner(c => c.AddPostgres()
                            .WithGlobalConnectionString(connectionString)
                            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
                    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>
    (options => options.UseNpgsql(builder.Configuration["5eCombatTracker"]));

builder.Services.AddScoped<IMonsterService, MonsterService>();
builder.Services.AddScoped<IEncounterService, EncounterService>();
builder.Services.AddScoped<IDbSeeder, DbSeeder>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Migrate();
app.UseDbSeederMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
