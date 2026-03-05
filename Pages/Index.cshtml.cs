using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using airBnB.Data;
using airBnB.models;
using System.Security.Cryptography.Pkcs;

namespace airBnB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly airBnBContext _context;


        public IndexModel(ILogger<IndexModel> logger,airBnBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string search { get; set; }

        public IList<RoomBooking> RoomBooking { get; set; } = default!;

        public void OnGet()
        {
            RoomBooking = _context.RoomBookings.FromSqlRaw("SELECT * FROM RoomBookings").ToList();
        }
    }
}
