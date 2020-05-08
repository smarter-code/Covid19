using Covid19.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public interface IPatientService
    {
        Task<List<Patient>> Get();
        Task<Patient> Get(int id);
        Task<Patient> Add(Patient patient);
        Task<Patient> Update(Patient patient);
        Task<Patient> Delete(int id);
    }
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Patient>> Get()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> Get(int id)
        {
            var toDo = await _context.Patients.FindAsync(id);
            return toDo;
        }

        public async Task<Patient> Add(Patient toDo)
        {
            _context.Patients.Add(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<Patient> Update(Patient toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return toDo;
        }

        public async Task<Patient> Delete(int id)
        {
            var toDo = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(toDo);
            await _context.SaveChangesAsync();
            return toDo;
        }
    }
}
