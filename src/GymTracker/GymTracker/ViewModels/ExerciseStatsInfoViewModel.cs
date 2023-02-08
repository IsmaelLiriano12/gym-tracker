using GymTrackerShared.Data;
using GymTrackerShared.Models.WgerModels;
using GymTrackerShared.Models;
using GymTrackerShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace GymTracker.ViewModels
{
    public class ExerciseStatsInfoViewModel : BaseExerciseInfoViewModel
    {
        private readonly IWgerService wgerService;
        private readonly IExercisesStatsRepository exercisesStatsRepository;
        private ExerciseStats exerciseStats;

        public decimal Weight
        {
            get
            {
                return exerciseStats.Weight;
            }
        }  
        
        public decimal Reps
        {
            get
            {
                return exerciseStats.Repetitions;
            }
        }  
        
        public decimal Sets
        {
            get
            {
                return exerciseStats.Repetitions;
            }
        }

        public ExerciseStatsInfoViewModel(IWgerService wgerService, IExercisesStatsRepository exercisesStatsRepository)
            :base(wgerService)
        {
            this.wgerService = wgerService;
            this.exercisesStatsRepository = exercisesStatsRepository;
        }

        public override async Task Init(int exerciseId)
        {
            exerciseStats = await exercisesStatsRepository.GetAsync(exerciseId);
            base.exerciseBaseInfo = await wgerService.GetExerciseBaseInfoAsync(exerciseStats.ExerciseBaseId);

            foreach (var exercise in base.exerciseBaseInfo.Exercises)
            {
                if (exercise.Language == 2)
                {
                    ExerciseBaseName = exercise.Name;
                    break;
                }
            }
        }

        public int GetExerciseStatsId()
        {
            return exerciseStats.Id;
        }
        
        public int GetExerciseStatsRoutineId()
        {
            return exerciseStats.RoutineId;
        }

        public override bool IsNull()
        {
            return exerciseStats == null || exerciseBaseInfo == null;
        }
    }
}
