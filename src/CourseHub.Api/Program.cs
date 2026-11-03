using CourseHub.Core.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CourseHubDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CourseHub")));

var app = builder.Build();

app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
{
    var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    await context.Response.WriteAsJsonAsync(new { error = error?.Message });
}));

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseHubDbContext>();
    db.Database.EnsureCreated();
    DbSeeder.Seed(db);
}

app.MapControllers();

app.Run();
