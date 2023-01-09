﻿using GymTrackerShared.Models;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IProfileDataRepository : IWriteRepository<ProfileData>
    {
        Task<ProfileData> GetProfileDataAsync(string UserId);
    }
}