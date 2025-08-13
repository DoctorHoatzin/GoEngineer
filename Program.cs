using Microsoft.EntityFrameworkCore;
using Database;
using GalaxyFarFarAway.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<StarWarsApiSettings>(builder.Configuration.GetSection("StarWarsApi"));
builder.Services.AddHttpClient<StarWarsAPIService>();
builder.Services.AddHostedService<StarWarsDatabaseSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
try
{
    using var connection = new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
    connection.Open();
    Console.WriteLine("Connection successful!");
}
catch (Exception ex)
{
    Console.WriteLine("Connection Unsuccessful!");
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Starship}/{action=Index}/{id?}");

app.Run();
