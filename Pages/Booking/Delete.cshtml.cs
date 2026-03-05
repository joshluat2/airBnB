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
    public class DeleteModel : PageModel
    {
        private readonly airBnB.Data.airBnBContext _context;

        public DeleteModel(airBnB.Data.airBnBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roombooking = await _context.RoomBookings.FindAsync(id);
            if (roombooking != null)
            {
                RoomBooking = roombooking;
                _context.RoomBookings.Remove(RoomBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
