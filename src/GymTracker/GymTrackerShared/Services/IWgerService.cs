using GymTrackerShared.Models;
using GymTrackerShared.Models.WgerModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymTrackerShared.Services
{
    public interface IWgerService
    {
        Task<IEnumerable<ExerciseBaseInfo>> GetExerciseBaseInfoCollectionAsync(int? variations = null);
        Task<IEnumerable<ExerciseBaseInfo>> GetExerciseBaseInfoSuggetionsAsync(string name);
        Task<ExerciseBaseInfo> GetExerciseBaseInfoAsync(int id);
        Task<IEnumerable<IngredientSuggestionResult>> GetIngredientSuggestionResultAsync(string name);
        Task<NutritionFacts> GetNutritionFactsAsync(int ingredientId, decimal amount);
    }
}