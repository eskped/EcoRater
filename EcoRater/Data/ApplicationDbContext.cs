using EcoRater.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoRater.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProjectFirm> ProjectFirms { get; set; }
    public DbSet<SustainabilityAssessment> SustainabilityAssessments { get; set; }
    public DbSet<RatingFeedback> RatingFeedbacks { get; set; }
}

