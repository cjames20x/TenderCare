using Microsoft.EntityFrameworkCore;
using Project.Data;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Connection String Setup
var csb = new MySqlConnectionStringBuilder
{
    Server = "localhost",
    Port = 3306,
    Database = "TenderCareDb",
    UserID = "root",
    Password = "PRESHEUN03"
};

// Connecting the TenderCareDbContext to MySQL
builder.Services.AddDbContext<TenderCareDbContext>(options =>
    options.UseMySql(csb.ConnectionString, ServerVersion.AutoDetect(csb.ConnectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Route Configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();