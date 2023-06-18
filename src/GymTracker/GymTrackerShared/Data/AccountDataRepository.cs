using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class AccountDataRepository : IAccountDataRepository
    {
        private readonly GymTrackerDbContext context;

        public AccountDataRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public void Add(AccountData entity)
        {
            context.Accounts.Add(entity);
        }

        public void Delete(AccountData entity)
        {
            context.Accounts.Remove(entity);
        }

        public async Task<AccountData> GetAccountDataAsync(string UserId)
        {
            return await context.Accounts.FirstOrDefaultAsync(a => a.UserId == UserId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        public void Update(AccountData entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
