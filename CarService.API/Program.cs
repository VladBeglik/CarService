using System.Reflection;
using CarService.App.Infrastructure;
using CarService.Persistance;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(assembly);

    builder.Services
    .AddSingleton<IServiceDbContext, ServiceDbContext>(o => new ServiceDbContext(builder.Configuration.GetConnectionString("Context")!));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// {
//     using var scope = app.Services.CreateScope();
//     var context = scope.ServiceProvider.GetRequiredService<IServiceDbContext>();
//     await context.Init();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();