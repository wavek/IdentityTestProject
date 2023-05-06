﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreIdentityApp.Web.Models
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>//string random guid değerler oluşturacak kullanıcılar oluşturulurken
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



    }
}
