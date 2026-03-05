using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using airBnB.Data;
using airBnB.models;

namespace airBnB.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly airBnB.Data.airBnBContext _context;

        public EditModel(airBnB.Data.airBnBContext context)
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

            var roombooking =  await _context.RoomBookings.FirstOrDefaultAsync(m => m.Id == id);
            if (roombooking == null)
            {
                return NotFound();
            }
            RoomBooking = roombooking;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RoomBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomBookingExists(RoomBooking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoomBookingExists(int id)
        {
            return _context.RoomBookings.Any(e => e.Id == id);
        }
    }
}
