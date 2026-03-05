using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using airBnB.models;

namespace airBnB.Data
{
    public class airBnBContext : DbContext
    {
        public airBnBContext (DbContextOptions<airBnBContext> options)
            : base(options)
        {
        }

        public DbSet<airBnB.models.RoomBooking> RoomBookings { get; set; } = default!;
    }
}
