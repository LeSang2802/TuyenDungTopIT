using Microsoft.EntityFrameworkCore;
using TuyenDungTopIT.BusinessLogicLayer;
using TuyenDungTopIT.DataAccessLayer;
using TuyenDungTopIT.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Thêm DbContext vào dịch vụ
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<JobRepository, JobRepository>(); // Đăng ký interface và implementation
builder.Services.AddScoped<JobService>(); // Đăng ký lớp service



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
    pattern: "{controller=JobSearch}/{action=Index}/{id?}");

app.Run();
