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

builder.Services.AddIdentityWithExtension();//custom sýnýfýmýz

//

//

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder=new CookieBuilder();
    cookieBuilder.Name = "MyIdentityCookie";
    opt.LoginPath = new PathString("/Home/SignIn");
    opt.Cookie=cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;//true olmazsa 60 gün kullanýcý kullanýr 61.gün eriþilemez olur.ama true olunca kullanýcý 30.gün giriþ
                                 //yaptý 60 gün daha uzatýr 90 gün olmuþ gibi olur 60 gün hiç giriþ yapamzsa 61.gün tekrar giriþ yapmasý gerekir
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
