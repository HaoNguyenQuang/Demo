using Microsoft.EntityFrameworkCore;
using ThucTapChuyenMon.Models;
using ThucTapChuyenMon.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("QltvApiContext");
builder.Services.AddDbContext<QltvApiContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<ThucTapChuyenMon.Repository.ITheLoaiSachRepository, ThucTapChuyenMon.Repository.TheLoaiSachRepository>();
builder.Services.AddScoped<IMuonSachService, MuonSachService>();
builder.Services.AddScoped<ThucTapChuyenMon.Areas.Admin.Repository.ITheLoaiSachRepository, ThucTapChuyenMon.Areas.Admin.Repository.TheLoaiSachRepository>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

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
app.UseSession();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
