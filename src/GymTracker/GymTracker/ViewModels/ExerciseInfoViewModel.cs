using GymTrackerShared.Data;
using GymTrackerShared.Models;
using GymTrackerShared.Models.WgerModels;
using GymTrackerShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GymTracker.ViewModels
{
    public class ExerciseInfoViewModel : BaseExerciseInfoViewModel
    {
        private readonly IWgerService wgerService;
        public ExerciseStats ExerciseStats;

        public int? Variations
        {
            get
            {
                return exerciseBaseInfo.Variations;
            }
        }

        public ExerciseInfoViewModel(IWgerService wgerService)
            :base(wgerService)
        {
            this.wgerService = wgerService;
        }


        public override bool IsNull()
        {
            return base.exerciseBaseInfo == null;
        }
    }
}
