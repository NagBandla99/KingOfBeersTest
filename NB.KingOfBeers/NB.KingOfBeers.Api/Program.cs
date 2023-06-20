using Microsoft.EntityFrameworkCore;
using NB.KingOfBeers.Api.Validators;
using NB.KingOfBeers.Application.Mappers;
using NB.KingOfBeers.Application.Services;
using NB.KingOfBeers.Application.Services.Contracts;
using NB.KingOfBeers.DataAccess;
using NB.KingOfBeers.Database.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(StartupBase), typeof(BeerMapperProfile));

builder.Services.AddValidatorsFromAssemblyContaining<AddBeerValidator>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IBeerService, BeerService>();

builder.Services.AddDbContext<KobDataContext>(item =>
    {
        var conString = builder.Configuration.GetConnectionString("sql_connection");
        if (string.IsNullOrWhiteSpace(conString))
        {
            throw new InvalidOperationException("No connection string found");
        }
        item.UseSqlite(conString);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
