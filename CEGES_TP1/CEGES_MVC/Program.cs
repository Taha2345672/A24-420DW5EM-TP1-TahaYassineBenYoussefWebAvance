
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CEGES_DataAccess.data;
using CEGES_Service.IService;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CEGESDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddControllersWithViews()
.Services.AddDbContext<CEGESDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IEntrepriseService, EntrepriseService>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddDefaultTokenProviders().AddDefaultUI()
               .AddEntityFrameworkStores<CEGESDbContext>();



builder.Services.AddDistributedMemoryCache();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "Configuration",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    name: "default",
    areaName: "Configuration",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();