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
    public class IndexModel : PageModel
    {
        private readonly Covid19.Data.ApplicationDbContext _context;

        public IndexModel(Covid19.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patients.ToListAsync();
        }
    }
}
