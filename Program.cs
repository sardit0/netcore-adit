using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventaris.Data;
using Inventaris.Models;

var builder = WebApplication.CreateBuilder(args);

// Menambahkan DbContext dengan SQLite
builder.Services.AddDbContext<InventarisContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("InventarisContext") ?? 
    throw new InvalidOperationException("Connection string 'InventarisContext' not found.")));

// Menambahkan Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<InventarisContext>()
    .AddDefaultTokenProviders();

// Konfigurasi IdentityOptions
builder.Services.Configure<IdentityOptions>(options =>
{
    // Konfigurasi Password
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    // Konfigurasi Lockout
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Konfigurasi User
    options.User.RequireUniqueEmail = true;
});

// Menambahkan layanan untuk MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Mengonfigurasi HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Menambahkan middleware untuk autentikasi dan otorisasi
app.UseAuthentication(); // Pastikan ini dipanggil sebelum UseAuthorization
app.UseAuthorization();

// Mengonfigurasi routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
