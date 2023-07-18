using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using Microsoft.EntityFrameworkCore;
using Petland_Shop.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopCenter; });
builder.Services.AddDbContext<DbMarketsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbMarkets")));
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));


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

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
