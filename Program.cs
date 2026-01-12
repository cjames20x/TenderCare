using Microsoft.EntityFrameworkCore;
using Project.Data;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Database Connection String
var csb = new MySqlConnectionStringBuilder
{
    Server = "localhost",
    Port = 3306,
    Database = "TenderCareDb",
    UserID = "root",
    Password = "PRESHEUN03"
};

builder.Services.AddDbContext<TenderCareDbContext>(options =>
    options.UseMySql(csb.ConnectionString, ServerVersion.AutoDetect(csb.ConnectionString)));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();