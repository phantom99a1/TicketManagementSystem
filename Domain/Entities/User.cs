﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string? Avatar { get; set; }

        public bool AccountConfirmed { get; set; }
    }
}
