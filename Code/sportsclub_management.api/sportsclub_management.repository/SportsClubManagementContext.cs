using sportsclub_management.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.repository
{
	public class SportsClubManagementContext : DbContext
	{
		public SportsClubManagementContext(DbContextOptions<SportsClubManagementContext> options) : base(options)
		{

		}

		public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity => base.Set<TEntity>();

		public DbSet<MasterGame> MasterGame { get; set; }
		public DbSet<MasterPlayer> MasterPlayer { get; set; }
		public DbSet<MasterCoach> MasterCoach { get; set; }
		public DbSet<MasterEquipment> MasterEquipment { get; set; }
		public DbSet<MasterRole> MasterRole { get; set; }
		public DbSet<PlayerGameMap> PlayerGameMap { get; set; }
		public DbSet<GameEquipmentMap> GameEquipmentMap { get; set; }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Feedback> Feedback { get; set; }
		public DbSet<CoachAddress> CoachAddress { get; set; }
	}
}
