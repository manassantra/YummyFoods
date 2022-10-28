
using YummyFood.Web;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>();
ServiceDirectory.ProductAPIBase = builder.Configuration["ServiceUrls:ProductService"];

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllersWithViews();
/*builder.Services.AddAuthentication();*/
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

// app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
