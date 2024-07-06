using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;
using System.Reflection;
using Todos.Core;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(CachedQueryHandlerPipelineBehavior<,>));
    options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(InvalidateCacheCommandHandlerPipelineBehavior<,>));
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSingleton<ICacheService, CacheService>();


var app = builder.Build();
app.UseHttpsRedirection();

app.UseFastEndpoints().UseSwaggerGen();

app.Run();
