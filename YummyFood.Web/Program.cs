
using YummyFood.Web;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>();
ServiceDirectory.ProductAPIBase = builder.Configuration["ServiceUrls:ProductService"];

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
   .AddCookie("Cookies", t => t.ExpireTimeSpan = TimeSpan.FromHours(15))
   .AddOpenIdConnect("oidc", options =>
   {
       options.Authority = builder.Configuration["ServiceUrls:AuthUrl"];
       options.GetClaimsFromUserInfoEndpoint = true;
       options.ClientId = "yummyfood-F5869";
       options.ClientSecret = "F5869A3C985EB89C99356FA24B1B9";
       options.ResponseType = "code";
       options.TokenValidationParameters.NameClaimType = "name";
       options.TokenValidationParameters.RoleClaimType = "role";
       options.Scope.Add("yummyfood");
       options.SaveTokens = true;
   });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
