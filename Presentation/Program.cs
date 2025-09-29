using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Helper;
using Presentation.Interfaces;
using Presentation.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseMySQL("server=localhost;database=twitter;user=root;password=;"));
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
builder.Services.AddSingleton<IMapper, Mapper>();


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