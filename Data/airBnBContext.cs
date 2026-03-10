using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using airBnB.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace airBnB.Data
{
    public class airBnBContext : IdentityDbContext
    {
        public airBnBContext (DbContextOptions<airBnBContext> options)
            : base(options)
        {
        }

        public DbSet<airBnB.models.RoomBooking> RoomBookings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RoomBooking>().ToTable(nameof(RoomBookings));
        }
    }
}
