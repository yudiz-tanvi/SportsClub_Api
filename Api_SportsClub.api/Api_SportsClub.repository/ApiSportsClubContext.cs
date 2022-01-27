﻿using Api_SportsClub.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api_SportsClub.repository
{
	public class ApiSportsClubContext : DbContext
	{
		public ApiSportsClubContext(DbContextOptions<ApiSportsClubContext> options) : base(options)
		{

		}

		public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity => base.Set<TEntity>();

		public DbSet<MasterGame> MasterGames { get; set; }
		public DbSet<MasterPlayer> MasterPlayer { get; set; }
		public DbSet<MasterCoach> MasterCoach { get; set; }
		public DbSet<MasterEquipment> MasterEquipment { get; set; }
		public DbSet<MasterRole> MasterRole { get; set; }
		public DbSet<PlayerGameMap> PlayerGameMap { get; set; }
		public DbSet<GameEquipmentMap> GameEquipmentMap { get; set; }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Feedback> Feedback { get; set; }
		public DbSet<CoachAdress> CoachAddress { get; set; }
	}
}
