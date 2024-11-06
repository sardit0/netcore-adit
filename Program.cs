using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventaris.Data;
using Inventaris.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventarisContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("InventarisContext") ?? 
    throw new InvalidOperationException("Connection string 'InventarisContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<InventarisContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
