using TorneioAWS.IoC;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using TorneioAWS.Repository.Comum.Contextos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDI();

builder.Services.AddDbContext<TorneioContext>(options => options
                .UseMySQL("server=localhost;port=3307;database=aws-projeto-final;user=admin;password=banco2022")
                .EnableSensitiveDataLogging());

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
