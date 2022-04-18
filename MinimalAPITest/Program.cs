using Microsoft.AspNetCore.Mvc;
using MinimalAPITest.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

var app = builder.Build();


app.MapGet("/api/todo/all", async ([FromServices] ITodoItemRepository repository) =>
{
    return repository.GetAll();
});

app.MapGet("/api/todo/{id}", async ([FromServices] ITodoItemRepository repository, int id) =>
{
    return repository.GetById(id);
});

app.MapPost("/api/todo/{id}", async ([FromServices] ITodoItemRepository repository, TodoItem item) =>
{
    repository.Add(item);
    return Results.Created($"api/todo/{item.Id}",item);
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
