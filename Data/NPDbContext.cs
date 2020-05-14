using System;
using NPWeatherService.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NPWeatherService.Data
{
	public class NPDbContext : DbContext
	{
		public NPDbContext (DbContextOptions<NPDbContext> options) : base(options)
		{
		}

		public DbSet<Park> Parks { get; set; }
		public DbSet<Survey> Surveys { get; set; }

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<Weather>();   // Weather class will not be mapped to a table in the database

			modelBuilder.Entity<Park>().ToTable("Park");
			modelBuilder.Entity<Park>().HasKey("ParkCode");
			modelBuilder.Entity<Park>().Property(p => p.ParkCode).HasMaxLength(5);
			modelBuilder.Entity<Park>().Property(p => p.State).HasMaxLength(25);
			modelBuilder.Entity<Park>().Property(p => p.ParkName).HasMaxLength(35);
			modelBuilder.Entity<Park>().Property(p => p.Climate).HasMaxLength(10);
			modelBuilder.Entity<Park>().Property(p => p.InspirationalQuoteSource).HasMaxLength(25);
			modelBuilder.Entity<Park>().Property(p => p.MilesOfTrail).HasColumnType("decimal(5, 1)");
			modelBuilder.Entity<Park>().Property(p => p.Latitude).HasColumnType("decimal(10, 6)");
			modelBuilder.Entity<Park>().Property(p => p.Longitude).HasColumnType("decimal(10, 6)");
			modelBuilder.Entity<Park>().Property(p => p.EntryFee).HasColumnType("Money");

			modelBuilder.Entity<Survey>().ToTable("Survey");
			modelBuilder.Entity<Survey>().Property(s => s.State).HasMaxLength(2);
			modelBuilder.Entity<Survey>().Property(s => s.ActivityLevel).HasMaxLength(20);
			modelBuilder.Entity<Survey>().Property(s => s.EmailAddress).HasMaxLength(50);
		}
	}	
}
