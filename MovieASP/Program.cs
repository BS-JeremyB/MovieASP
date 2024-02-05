using Microsoft.Data.SqlClient;
using MovieASP.DAL.Repositories;
using MovieASP.DAL.Services;
using MovieASP.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieRepository, MovieService>();
builder.Services.AddTransient<SqlConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("default")));
//builder.Services.AddSingleton<MovieData>();



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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
