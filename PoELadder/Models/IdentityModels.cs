﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PoELadder.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<StandardPlayer> StandardPlayers { get; set; }
        public DbSet<StandardHCPlayer> StandardHCPlayers { get; set; }
        public DbSet<StandardSSFPlayer> StandardSSFPlayers { get; set; }
        public DbSet<StandardHCSSFPlayer> StandardHCSSFPlayers { get; set; }
        public DbSet<CurrentLeaguePlayer> CurrentLeaguePlayers { get; set; }
        public DbSet<CurrentLeagueSSFPlayer> CurrentLeagueSSFPlayers { get; set; }
        public DbSet<CurrentLeagueHCPlayer> CurrentLeagueHCPlayers { get; set; }
        public DbSet<CurrentLeagueHCSSFPlayer> CurrentLeagueHCSSFPlayers { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}