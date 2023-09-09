using System;
using Microsoft.AspNetCore.Identity;

namespace EcoRater.Models
{
    public class ProjectFirm
    {
        public int Id { get; set; } // Primary Key
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Region { get; set; }
        public string? UserId { get; set; } // Foreign Key to User

        // Navigation Property
        public IdentityUser? User { get; set; }
    }
}
