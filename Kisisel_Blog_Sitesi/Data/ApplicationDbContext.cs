using Kisisel_Blog_Sitesi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kisisel_Blog_Sitesi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<GalleryPhoto> GalleryPhotos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
