using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<User>(options)
    {
        DbSet<Ticket> Tickets { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Priority> Prioritys { get; set; }

        DbSet<Discussion> Discussions { get; set;}

        DbSet<Category> Categorys { get; set; }

        DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.GenerateSeed();

            builder.Entity<Ticket>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Discussion>()
                .HasOne(e => e.Ticket)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
