using GymTrackerShared.Data;
using GymTrackerShared.Models;
using GymTrackerShared.Models.WgerModels;
using GymTrackerShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace GymTracker.ViewModels
{
    public abstract class BaseExerciseInfoViewModel
    {
        private readonly IWgerService wgerService;

        protected ExerciseBaseInfo exerciseBaseInfo;

        public string ExerciseBaseName { get; protected set; }
        public string Description { get; protected set; }

        public string Category
        {
            get
            {
                return exerciseBaseInfo.Category.Name;
            }
        }

        public IEnumerable<string> PrimaryMuscles
        {
            get
            {
                var primaryMuscles = new List<string>();

                foreach (var muscle in exerciseBaseInfo.Muscles)
                {
                    primaryMuscles.Add(muscle.Name);
                }
                return primaryMuscles;
            }
        }

        public IEnumerable<string> SecondaryMuscles
        {
            get
            {
                var secondaryMuscles = new List<string>();

                foreach (var muscle in exerciseBaseInfo.MusclesSecondary)
                {
                    secondaryMuscles.Add(muscle.Name);
                }
                return secondaryMuscles;
            }
        }


        public BaseExerciseInfoViewModel(IWgerService wgerService)
        {
            this.wgerService = wgerService;
        }

        public virtual async Task Init(int exerciseId)
        {
            exerciseBaseInfo = await wgerService.GetExerciseBaseInfoAsync(exerciseId);

            foreach (var exercise in exerciseBaseInfo.Exercises)
            {
                if (exercise.Language == 2)
                {
                    ExerciseBaseName = exercise.Name;
                    Description = exercise.Description;
                    break;
                }
            }
        }

        public string GetImage()
        {
            if (exerciseBaseInfo.Images.Count == 0)
                return "https://localhost:44317/Content/Img/no-image.PNG";

            return exerciseBaseInfo.Images.FirstOrDefault().ImageUrl;
        }

        public abstract bool IsNull();
    }
}
