using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models
{
	public class MasterGame : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public ICollection<MasterCoach> MasterCoach { get; set; }

		public ICollection<GameEquipmentMap> GameEquipmentMap { get; set; }

		public ICollection<PlayerGameMap> PlayerGameMap { get; set; }

		public ICollection<Feedback> Feedback { get; set; }
	}
}
