using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using airBnB.Data;
using airBnB.models;

namespace airBnB.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly airBnB.Data.airBnBContext _context;

        public CreateModel(airBnB.Data.airBnBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoomBooking RoomBooking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RoomBookings.Add(RoomBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
