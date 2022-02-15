using Microsoft.EntityFrameworkCore;
using sportsclub_management.models;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Helpers
{
	public class SeedHelpers
	{
        SportsClubManagementContext DbContext { get; set; }

        public SeedHelpers(SportsClubManagementContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task Seed()
        {
            // Code for check that values is in Master Roles or not
            //if (DbContext.MasterGame.Any()) return;  // Early Return

            var mastergameRequest = new List<MasterGame>
            {
                new MasterGame
                {
                    Name = "Hockey",
                },

                new MasterGame {
                    Name = "Badminton",
                },

                
            };

            await DbContext.MasterGame.AddRangeAsync(mastergameRequest); // Bulk insert


            //if (DbContext.MasterPlayer.Any()) return;  // Early Return

            var masterplayerRequest = new List<MasterPlayer>
            {
                new MasterPlayer
                {
                    Name = "Tanvi",
                    Mobile = 7777772221,
                    AadharNumber = "123456789012",
                    Fees = 2000,
                    Email = "tanvi@gmail.com",
                    JoiningDate = DateTime.Now,
                },

                new MasterPlayer 
                {
                    Name = "Amisha",
                    Mobile = 7777772221,
                    AadharNumber = "123456789012",
                    Fees = 2000,
                    Email = "tanvi@gmail.com",
                    JoiningDate = DateTime.Now,
                },


            };

            await DbContext.MasterPlayer.AddRangeAsync(masterplayerRequest); // Bulk insert

            //if (DbContext.MasterEquipment.Any()) return;  // Early Return

            var masterequipmentRequest = new List<MasterEquipment>
            {
                new MasterEquipment
                {
                    Name = "Ball",
                    Quantity = 10,
                },

                new MasterEquipment
                {
                    Name = "Bat",
                    Quantity = 20,
                },


            };

            await DbContext.MasterEquipment.AddRangeAsync(masterequipmentRequest); // Bulk insert

            var masterroleRequest = new List<MasterRole>
            {
                new MasterRole
                {
                    Name = "Tanvi",
                    Display_Name = "Tanvi",
                },

                new MasterRole
                {
                    Name = "Amisha",
                    Display_Name = "Amisha",
                },


            };

            await DbContext.MasterRole.AddRangeAsync(masterroleRequest); // Bulk insert

            await DbContext.SaveChangesAsync();
        }
    }
}
