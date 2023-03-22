using Covid19.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public interface IHospitalService
    {
        Task<List<Hospital>> Get();
        Task<Hospital> Get(int id);
        Task<Hospital> Add(Hospital patient);
        Task<Hospital> Update(Hospital patient);
        Task<Hospital> Delete(int id);
    }
    public class HospitalService : IHospitalService
    {
        private readonly ApplicationDbContext _context;

        public HospitalService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Hospital>> Get()
        {
            return await _context.Hospitals.Include(h => h.User).Include(h => h.State).ToListAsync();
        }
        public async Task<Hospital> Get(int id)
        {
            var toDo = await _context.Hospitals.FindAsync(id);
            return toDo;
        }

        public async Task<Hospital> Add(Hospital toDo)
        {
            _context.Hospitals.Add(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<Hospital> Update(Hospital toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<Hospital> Delete(int id)
        {
            var toDo = await _context.Hospitals.FindAsync(id);
            _context.Hospitals.Remove(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }
    }
}
