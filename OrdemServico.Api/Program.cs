using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.DependencyInjection;
using OrdemServico.Api.Mappings;
using OrdemServico.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONEXÃO DB
var connectionString = builder.Configuration.GetConnectionString("DefaultDbConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

// MAPPERS
builder.Services.AddAutoMapper(typeof(MappingProfile));

// PUBLICAR REPOSITORIOS
builder.Services.AddRepositories();

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
