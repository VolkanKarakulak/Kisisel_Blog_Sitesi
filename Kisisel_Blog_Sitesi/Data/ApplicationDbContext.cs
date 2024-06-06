using Kisisel_Blog_Sitesi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kisisel_Blog_Sitesi.Data
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
