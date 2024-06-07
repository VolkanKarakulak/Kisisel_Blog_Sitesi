using VolkanKarakulakPortfolio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VolkanKarakulakPortfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GalleryPhoto> GalleryPhotos { get; set; }
        public DbSet<EducationContent> EducationContent { get; set; } = default!;
    }
}
