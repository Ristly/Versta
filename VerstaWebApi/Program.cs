using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VerstaWebApi.Contexts;
using VerstaWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddDbContext<ApplicationDbContext>((options )=>
{
    var connectionString = builder.Configuration.GetConnectionString("LocalConnection");
    options.UseSqlServer(connectionString);
    
});



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7118", "https://localhost:7267")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().ApplyMigration();


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

app.Run();
