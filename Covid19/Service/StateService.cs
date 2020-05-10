using Covid19.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public interface IStateService
    {
        Task<List<State>> Get();
    }
    public class StateService : IStateService
    {
        private readonly ApplicationDbContext _context;

        public StateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<State>> Get()
        {
            return await _context.States.ToListAsync();
        }
    }


}
