using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CEGES_DataAccess;
using CEGES_Services;
using CEGES_Service;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configuration de la base de données
builder.Services.AddDbContext<CEGESDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajout des services pour DI
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IServiceBaseAsync<>), typeof(ServiceBase<>));
builder.Services.AddScoped<IEntrepriseService, EntrepriseService>(); // Utilisation de l'implémentation correcte
builder.Services.AddScoped<IGroupeService, GroupeService>();
builder.Services.AddScoped<IEquipementConstantesService, EquipementConstantesService>();
builder.Services.AddScoped<IEquipementLineairesService, EquipementLineairesService>();
builder.Services.AddScoped<IEquipementRelativesService, EquipementRelativesService>();

// Configuration des caches distribués (si nécessaire)
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Gestion des erreurs
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS pour les environnements de production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configuration des routes
app.MapControllerRoute(
    name: "Configuration",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Démarrage de l'application
app.Run();
