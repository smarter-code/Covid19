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
            var status = await _context.Patients.Select(p => p.Status).Distinct().ToListAsync();
            var reportEntries = new List<AggregatedReportEntry>();
            //foreach (var state in status)
            //{
            //    reportEntries.Add(new AggregatedReportEntry()
            //    {
            //        State = state,
            //        Count = _context.Patients
            //        .Where(p => p.Status == state).Count()
            //    });
            //}

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
