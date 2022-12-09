using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class ProfileDataRepository : IProfileDataRepository
    {
        private readonly GymTrackerDbContext context;

        public ProfileDataRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public void Add(ProfileData entity)
        {
            context.Profiles.Add(entity);
        }

        public void Delete(ProfileData entity)
        {
            context.Profiles.Remove(entity);
        }

        public async Task<ProfileData> GetProfileData(string UserId)
        {
            return await context.Profiles.FirstOrDefaultAsync(p => p.UserId == UserId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        public void Update(ProfileData entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
