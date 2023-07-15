using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Context;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace MVCStartApp.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly BlogContext _context;

        public FeedbackRepository(BlogContext context) 
        {
            _context = context;

        }

        public async Task Add(Feedback feedback)
        {
            feedback.Id = Guid.NewGuid();

            var entity = _context.Entry(feedback);
            if (entity.State == EntityState.Detached)
                await _context.Feedbacks.AddAsync(feedback);

            await _context.SaveChangesAsync();
        }

        public async Task<Feedback[]> GetFeedbacks()
        {
            var feedbacks = _context.Feedbacks.ToArrayAsync();
            return await feedbacks;
        }
    }
}
