
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ReviewsAppDbContext :  IdentityDbContext<AppUser>
	{

		public ReviewsAppDbContext(DbContextOptions<ReviewsAppDbContext> options)
			: base(options)
		{
		}

	
		public DbSet<AppUser> appUsers { get; set; }
		public DbSet<Comment> comments { get; set; }

		public DbSet<Genre> genres { get; set; }
	
		public DbSet<Review> reviews { get; set; }
		public DbSet<Tag> tags { get; set; }

		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Genre>().HasData(
				new Genre { Id = 1, Name = "Fantasy" },
				new Genre { Id = 2, Name = "Crime" },
				new Genre { Id = 3, Name = "Romance" },
				new Genre { Id = 4, Name = "Childrens" },
				new Genre { Id = 5, Name = "Historical" }
	

			);
            modelBuilder.Entity<Comment>()
    .HasOne(c => c.Review)
    .WithMany(r => r.Comments)
    .HasForeignKey(c => c.ReviewId)
    .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
