app.MapGet("/api/tasks", async (TaskDbContext db) =>
{
    var tasks = await db.Tasks.ToListAsync();
    return Results.Ok(tasks);
});

app.MapGet("/api/tasks/{id:int}", async (int id, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    return task is null ? Results.NotFound() : Results.Ok(task);
});

app.MapPost("/api/tasks", async (CreateTaskRequest request, TaskDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(request.Title) || request.Title.Length > 100)
        return Results.BadRequest("Title is required and must be 100 characters or fewer.");

    var task = new TaskItem { Title = request.Title };
    db.Tasks.Add(task);
    await db.SaveChangesAsync();

    return Results.Created($"/api/tasks/{task.Id}", task);
});

app.MapPut("/api/tasks/{id:int}", async (int id, UpdateTaskRequest request, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    if (string.IsNullOrWhiteSpace(request.Title) || request.Title.Length > 100)
        return Results.BadRequest("Title is required and must be 100 characters or fewer.");

    task.Title = request.Title;
    task.IsComplete = request.IsComplete;
    await db.SaveChangesAsync();

    return Results.Ok(task);
});

app.MapDelete("/api/tasks/{id:int}", async (int id, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();

    return Results.NoContent();
});
