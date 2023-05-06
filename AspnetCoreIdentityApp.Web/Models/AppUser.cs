﻿using Microsoft.AspNetCore.Identity;

namespace AspnetCoreIdentityApp.Web.Models
{
    public class AppUser:IdentityUser
    {
        public string? City { get; set; }
    }
}
