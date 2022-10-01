using AutoMapper;
using GymTracker.ApiModels;
using GymTrackerShared.ApiModels;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class GymTrackerMappingProfile : Profile
    {
        public GymTrackerMappingProfile()
        {
            CreateMap<Routine, RoutineModel>()
                .ReverseMap();

            CreateMap<Exercise, ExerciseModel>()
                .ReverseMap();
        }
    }
}
