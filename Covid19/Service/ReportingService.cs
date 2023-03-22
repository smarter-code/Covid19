using Covid19.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{

    public interface IReportingService
    {
        Task<List<AggregatedReportEntry>> GetAggregatedReports();
    }
    public class ReportingService : IReportingService
    {
        private readonly ApplicationDbContext _context;


        public ReportingService(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<List<AggregatedReportEntry>> GetAggregatedReports()
        {
            var patients = await _context.Patients.Include(p => p.Status).ToListAsync();
            var groupedPatients =
                                from patient in patients
                                group patient by patient.Status.Name into newGroup
                                select newGroup;
            var reportEntries = groupedPatients.Select(g => new AggregatedReportEntry() { State = g.Key, Count = g.Count() }).ToList();
            reportEntries.Add(new AggregatedReportEntry() { State = "All Cases", Count = _context.Patients.Count() });
            return reportEntries;
        }
    }

    public class AggregatedReportEntry
    {
        public string State { get; internal set; }
        public int Count { get; internal set; }
    }
}
