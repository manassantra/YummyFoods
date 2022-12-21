using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YummyFood.Web;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
ServiceDirectory.ProductAPIBase = builder.Configuration["ServiceUrls:ProductService"];
ServiceDirectory.IdentityAPIBase = builder.Configuration["ServiceUrls:IdentityService"];

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
 .AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(builder.Configuration["Jwt:Key"]))
    };
})
 .AddCookie(opt =>
{
    opt.Cookie.Name = "yum_cId";
    opt.Cookie.Domain = "localhost";
    opt.Cookie.Path = "/";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
});


builder.Services.AddMvc();

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
app.UseCors();
app.UseRouting();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
