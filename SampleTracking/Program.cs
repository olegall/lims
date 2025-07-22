using SampleTracking.Models;
using MessageBroker;
using MessageBroker.Interfaces;
using SampleTracking.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = "Data Source=ms-sql-8.in-solve.ru;Database=1gb_city-move;User ID=1gb_city-move;Password=a4bea42fsg;TrustServerCertificate=True;";
builder.Services.AddTransient<ISampleRepository, SampleRepository>(provider => new SampleRepository(connectionString));
builder.Services.AddTransient<IProducer, Producer>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
