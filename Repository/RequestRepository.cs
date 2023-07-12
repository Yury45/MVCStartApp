using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Context;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository.Interfaces;
using System.Threading.Tasks;

namespace MVCStartApp.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext blogContext)
        {
            _context = blogContext;
        }

        public async Task AddRequest(Request request)
        {
            var entity = _context.Entry(request);
            if(entity.State == EntityState.Detached)
                await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public Task<Request[]> GetRequests()
        {
            throw new System.NotImplementedException();
        }
    }
}
