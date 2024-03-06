using DrumWebshop;
using DrumWebshop.Data;
using DrumWebshop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<DrumContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseStatusCodePages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//// Add items to database
//using var scope = app.Services.CreateScope();
//var serviceProvider = scope.ServiceProvider;
//var context = serviceProvider.GetRequiredService<DrumContext>();

//List<Snare> snares = DbInitializer.InitializeSnares(context);
//List<Shell> shells = DbInitializer.InitializeShells(context);
//List<Cymbal> hihats = DbInitializer.InitializeHihats(context);
//List<Cymbal> crashes = DbInitializer.InitializeCrashes(context);
//List<Cymbal> rides = DbInitializer.InitializeRides(context);
//List<Hardware> hardware = DbInitializer.InitializeHardware(context);
//context.AddRange(snares);
//context.AddRange(shells);
//context.AddRange(hihats);
//context.AddRange(crashes);
//context.AddRange(rides);
//context.AddRange(hardware);
//context.SaveChanges();


app.Run();