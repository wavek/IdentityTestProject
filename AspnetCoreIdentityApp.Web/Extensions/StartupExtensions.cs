using AspnetCoreIdentityApp.Web.CustomValidations;
using AspnetCoreIdentityApp.Web.Localizations;
using AspnetCoreIdentityApp.Web.Models;

namespace AspnetCoreIdentityApp.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //username default unique dir
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmmnoprestyvwxyz0123456789_*!";//defaultu var zaten property üzerine gel ünlem ekleyeceksen += deneyebilirsin
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;//?!* falan olsun mu diyor olmasın dedik
                options.Password.RequireLowercase = true;//küçük harf olsun
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;//sayısa karakter gerekli mi

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);//default 5 dakika kilitliyor
                options.Lockout.MaxFailedAccessAttempts = 6;//default 5 tir - max kaç kere giriş yapabilsin

            }).AddPasswordValidator<PasswordValidator>().AddUserValidator<UserValidator>().AddErrorDescriber<LocalizationIdentityErrorDescriber>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
