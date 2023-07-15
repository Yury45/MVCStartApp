using MVCStartApp.Models.Db;
using System.Threading.Tasks;

namespace MVCStartApp.Repository.Interfaces
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
