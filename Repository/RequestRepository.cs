using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Context;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStartApp.Repository
{
    public class RequestRepository : IRequestRepository
    {
        public BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.OrderBy(x => x.Date).ToArrayAsync();
        }

        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            var entity = _context.Entry(request);
            if(entity.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
        }
    }
}
