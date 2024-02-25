using FastEndpoints;
using todo.api.Core;
using todo.api.Domain.Todos;
using FastEndpoints.Swagger;
using todo.api.Features.Todos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints()
                .SwaggerDocument();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoRepository>(_ => new TodoRepository(new List<Todo>()));
builder.Services.AddSingleton<IMapper, AddTodoMapper>();

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();
app.UseHttpsRedirection();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
