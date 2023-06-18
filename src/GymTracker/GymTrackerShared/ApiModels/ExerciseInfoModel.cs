using static GymTrackerShared.Models.Routine;

namespace GymTrackerShared.ApiModels
{
    public class ExerciseInfoModel
    {
        public int ExerciseBaseId { get; set; }
        public string Name { get; set; }
        public TrainingDay TrainingDay { get; set; }
    }
}
