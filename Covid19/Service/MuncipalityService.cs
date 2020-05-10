using Covid19.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public interface IMuncipalityService
    {
        Task<List<Municipality>> Get();
    }
    public class MuncipalityService : IMuncipalityService
    {
        private readonly ApplicationDbContext _context;

        public MuncipalityService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Municipality>> Get()
        {
            return await _context.Municipalities.ToListAsync();
        }
    }


}
