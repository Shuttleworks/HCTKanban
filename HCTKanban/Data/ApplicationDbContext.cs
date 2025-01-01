using Microsoft.EntityFrameworkCore;
using HCTKanban.Models;

namespace HCTKanban.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Locations> Locations { get; set; }

		public DbSet<BirdBox> BirdBox { get; set; }

		public DbSet<BirdBoxType> BirdBoxType { get; set; }

		public DbSet<Status> Status { get; set; }


	}
}
