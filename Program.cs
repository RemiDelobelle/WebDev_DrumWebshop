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

//List<Product> products = DbInitializer.InitializeProducts(context);
//context.Products.AddRange(products);
//context.SaveChanges();


app.Run();