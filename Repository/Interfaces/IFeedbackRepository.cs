using MVCStartApp.Models.Db;
using System.Threading.Tasks;

namespace MVCStartApp.Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        Task Add(Feedback feedback);
        Task<Feedback[]> GetFeedbacks();
    }
}
