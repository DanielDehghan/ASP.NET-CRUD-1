using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//*********//
// Using builder.Service
// we have to tell aplication that we ant to use entity framework core
// we will add the key string of the Connection string which is DefaultConnection
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();


//Pipeline means when a request come to an application how do we want to process that 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();

// by adding this we are configuring the wwwroot path and all the static files there 
app.UseStaticFiles();

// adding routing to the request pipeline
app.UseRouting();

app.UseAuthorization();


// this tell our application how the routing should work 
// so here we have default route of our application
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.Run();
