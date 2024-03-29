using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.ApplicationServices;
using Shop.Hubs;
using Microsoft.AspNetCore.Identity;
using Shop.Core.Domain;
using Shop.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
builder.Services.AddScoped<IFileServices, FilesServices>();
builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAccuWeatherForecastServices, AccuWeatherForecastServices>();
builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
builder.Services.AddScoped<ICocktailServices, CocktailServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;
    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
    options.Lockout.MaxFailedAccessAttempts = 2;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
    .AddDefaultUI();

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
    o.TokenLifespan = TimeSpan.FromHours(5));

//email tokens confirmation
builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(o =>
o.TokenLifespan = TimeSpan.FromDays(3));

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

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider
    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});

app.UseRouting();
app.UseAuthentication();
app.MapRazorPages();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/ChatHub/chat");
app.Run();
