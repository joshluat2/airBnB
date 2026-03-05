using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using airBnB.Data;
using airBnB.models;

namespace airBnB.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly airBnB.Data.airBnBContext _context;

        public IndexModel(airBnB.Data.airBnBContext context)
        {
            _context = context;
        }

        public IList<RoomBooking> RoomBooking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RoomBooking = await _context.RoomBookings.ToListAsync();
        }
    }
}
