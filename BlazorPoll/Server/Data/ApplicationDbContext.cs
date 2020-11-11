using BlazorPoll.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPoll.Server.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<PollEntity>()
				.HasMany(p => p.PollOptions)
				.WithOne(po => po.Poll);
		}

		public DbSet<PollEntity> Polls { get; set; }

		public DbSet<PollOptionEntity> PollOptions { get; set; }

	}
}
