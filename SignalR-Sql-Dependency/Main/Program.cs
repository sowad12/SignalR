
using Main.Extensions;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Main.Manager;
using Main.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false);
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDatabaseContextService(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDependency(builder.Configuration);


//builder.Services.AddTransient<ISystemManager, SystemManager>();
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

app.MapHub<DashboardHub>("/dashboardHub");
app.Run();
