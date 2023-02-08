using GymTrackerShared.Models;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IAccountDataRepository : IWriteRepository<AccountData>
    {
        Task<AccountData> GetAccountDataAsync(string UserId);
    }
}