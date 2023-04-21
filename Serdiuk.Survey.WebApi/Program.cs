using Serdiuk.Survey.Application;
using Serdiuk.Survey.Infrastructure;
using Serdiuk.Survey.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(b =>
    {
        b.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000")
        .AllowCredentials();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AppDbContextSeed.Initialize(app.Services.CreateScope().ServiceProvider);

app.Run();
