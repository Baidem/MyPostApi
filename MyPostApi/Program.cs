using Repositories;
using Entities;
using Repositories.Contracts;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o =>
{  // Fix Include(p => p.Comments) : Error 500 "...JsonSerializerOptions to support cycles...
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<MyPostApiContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("MyPostApiDbCS"));

    // mode debug
    //o.LogTo(Console.Write);
});


// Forcer les migrations en attentes (évite de faire le update-database)
//using (var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;
//    var wikyContext = services.GetRequiredService<WikyContext>();
//    wikyContext.Database.Migrate();

//    //wikyContext.Database.EnsureDeleted(); // Efface la Db
//    //wikyContext.Database.EnsureCreated(); // Recrer la Db sans prendre en compte les migrations
//}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyPostApiContext>(); // Fix migration Init

builder.Services.AddScoped<IPostRepository, PostRepository>(); // Fix scope PostController
builder.Services.AddScoped<ICommentRepository, CommentRepository>();  // Fix scope CommentController
builder.Services.AddScoped<IUserRepository, UserRepository>();  // Fix scope UserController

var app = builder.Build();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

app.UseAuthentication();
app.UseAuthorization();

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
