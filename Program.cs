using SmartHome_Database;
using SmartHome_MVC;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddSingleton<SerialPortService>(); //My service to hosted communication with Serial Port

builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


var database = new SmartHomeDbContext();
database.Database.EnsureCreated();
DatabaseLocator.Database = database;


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Dashboard}/{id?}");

app.Run();
