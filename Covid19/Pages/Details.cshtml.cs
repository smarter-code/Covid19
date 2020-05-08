using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Covid19.Data;

namespace Covid19
{
    public class DetailsModel : PageModel
    {
        private readonly Covid19.Data.ApplicationDbContext _context;

        public DetailsModel(Covid19.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
