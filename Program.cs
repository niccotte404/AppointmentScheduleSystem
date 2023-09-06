using AppointmentScheduleSystem.Data;
using AppointmentScheduleSystem.Helpers;
using AppointmentScheduleSystem.Interfaces;
using AppointmentScheduleSystem.Repositiry;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICloudinaryRequest, CloudinaryRequest>(); // set implimentations of interfaces
builder.Services.AddScoped<ICompanyDbRequest, CompanyDbRequest>();
builder.Services.AddScoped<IScheduleDbRequest, ScheduleDbRequest>();
builder.Services.Configure<CloudinaryAccount>(builder.Configuration.GetSection("CloudinarySettings")); // send cloudinary account data from appsettings.json to used model
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); // create database context and get connection string from appsettings.json

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
