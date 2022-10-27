using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Yummy.IdentityService;
using Yummy.IdentityService.DbContexts;
using Yummy.IdentityService.Initializer;
using Yummy.IdentityService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Connect DB
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var identityBuilder = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(ServiceDirectory.IdentityResources)
   .AddInMemoryApiScopes(ServiceDirectory.ApiScopes)
   .AddInMemoryClients(ServiceDirectory.Clients)
   .AddAspNetIdentity<ApplicationUser>();

identityBuilder.AddDeveloperSigningCredential();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();    
builder.Services.AddControllersWithViews();


 var app = builder.Build();
 void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


SeedDatabase();

/*var scope = app.Services.CreateScope();

var initializerService = scope.ServiceProvider.GetService<IDbInitializer>();

initializerService.Initialize();*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
