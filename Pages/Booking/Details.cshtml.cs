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
    public class DetailsModel : PageModel
    {
        private readonly airBnB.Data.airBnBContext _context;

        public DetailsModel(airBnB.Data.airBnBContext context)
        {
            _context = context;
        }

        public RoomBooking RoomBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roombooking = await _context.RoomBookings.FirstOrDefaultAsync(m => m.Id == id);

            if (roombooking is not null)
            {
                RoomBooking = roombooking;

                return Page();
            }

            return NotFound();
        }
    }
}
