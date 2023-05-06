using AspnetCoreIdentityApp.Web.Extensions;
using AspnetCoreIdentityApp.Web.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

//
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentityWithExtension();//custom s�n�f�m�z

//

//

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder=new CookieBuilder();
    cookieBuilder.Name = "MyIdentityCookie";
    opt.LoginPath = new PathString("/Home/SignIn");
    opt.Cookie=cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;//true olmazsa 60 g�n kullan�c� kullan�r 61.g�n eri�ilemez olur.ama true olunca kullan�c� 30.g�n giri�
                                 //yapt� 60 g�n daha uzat�r 90 g�n olmu� gibi olur 60 g�n hi� giri� yapamzsa 61.g�n tekrar giri� yapmas� gerekir
    opt.LogoutPath = new PathString("/Member/Logout");
});

//


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
