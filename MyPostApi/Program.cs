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



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyPostApiContext>(); // Fix migration Init

builder.Services.AddScoped<IPostRepository, PostRepository>(); // Fix scope PostController
builder.Services.AddScoped<ICommentRepository, CommentRepository>();  // Fix scope CommentController
builder.Services.AddScoped<IUserRepository, UserRepository>();  // Fix scope UserController

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Forcer les migrations en attentes (évite de faire le update-database)
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var myPostApiContext = services.GetRequiredService<MyPostApiContext>();
    myPostApiContext.Database.Migrate();

    //myPostApiContext.Database.EnsureDeleted(); // Efface la Db
    //myPostApiContext.Database.EnsureCreated(); // Recrer la Db sans prendre en compte les migrations
}

app.Run();
