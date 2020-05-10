using Covid19.Data;
using Covid19.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public interface IStatusService
    {
        Task<List<Status>> Get();
    }
    public class StatusService : IStatusService
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public StatusService(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public async Task<List<Status>> Get()
        {
            var user = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            var singleRole = roles.FirstOrDefault();
            var result = await _context.Status.Where(s => RolesConfig.PatientStatusSecurityMatrix[singleRole].Contains(s.Name)).ToListAsync();
            return result;
        }
    }
}


