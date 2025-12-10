using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Đăng ký Repositories
builder.Services.AddScoped<ITinhCuRepository, EFTinhCuRepository>();
builder.Services.AddScoped<IHuyenCuRepository, EFHuyenCuRepository>();
builder.Services.AddScoped<IXaCuRepository, EFXaCuRepository>();
builder.Services.AddScoped<IXaMoiRepository, EFXaMoiRepository>();
builder.Services.AddScoped<ITinhMoiRepository, EFTinhMoiRepository>();

// Sự kiện hành chính + lịch sử sáp nhập
builder.Services.AddScoped<ISuKienHanhChinhRepository, EFSuKienHanhChinhRepository>();
builder.Services.AddScoped<ILichSuSapNhapRepository, EFLichSuSapNhapRepository>();
builder.Services.AddScoped<ILssnTinhRepository, EFLssnTinhRepository>();
builder.Services.AddScoped<ILssnXaRepository, EFLssnXaRepository>();

// Người dân + cư trú
builder.Services.AddScoped<INguoiDanRepository, EFNguoiDanRepository>();
builder.Services.AddScoped<IThuongTruRepository, EFThuongTruRepository>();
builder.Services.AddScoped<ITamTruRepository, EFTamTruRepository>();
builder.Services.AddScoped<ILichSuDiaChiRepository, EFLichSuDiaChiRepository>();

// Danh mục nền
builder.Services.AddScoped<ITrinhDoVanHoaRepository, EFTrinhDoVanHoaRepository>();
builder.Services.AddScoped<IDanTocRepository, EFDanTocRepository>();
builder.Services.AddScoped<ITonGiaoRepository, EFTonGiaoRepository>();
builder.Services.AddScoped<IQuanHeChuHoRepository, EFQuanHeChuHoRepository>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddDefaultTokenProviders()
.AddDefaultUI()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
// MVC
builder.Services.AddControllersWithViews();

// Build app SAU KHI đăng ký services
var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapRazorPages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Route cho Area (đặt TRƯỚC default route)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();
