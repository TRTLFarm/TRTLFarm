using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TRTLFarm.Models;
using TRTLFarm.Services.ServiceModels;
using TRTLFarm.ViewModels;

namespace TRTLFarm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<UserAnimals> UserAnimals { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<WebHookMessages> WebHookMessages { get; set; }
        public DbSet<AdminModel> AdminModel { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<UserLogHistory> UserLogHistory { get; set; }
        public DbSet<SpecialAnimal> SpecialAnimals { get; set; }
        public DbSet<TheftCooldown> TheftCooldown { get; set; }
    }
}
