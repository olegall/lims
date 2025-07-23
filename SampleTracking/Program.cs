using MessageBroker;
using MessageBroker.Interfaces;
using SampleTracking.Interfaces;
using SampleTracking.DAL;
using SampleTracking.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = "";
builder.Services.AddTransient<ISampleRepository, SampleRepository>(provider => new SampleRepository(connectionString));
builder.Services.AddTransient<IProducer, Producer>();
builder.Services.AddTransient<IMapper, Mapper>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
