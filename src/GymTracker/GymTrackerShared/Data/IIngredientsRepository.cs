using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public interface IIngredientsRepository : IWriteRepository<Ingredient>
    {
        Task<Ingredient> GetIngredientAsync(int id);
        Task<Dictionary<Meal, List<Ingredient>>> GetIngredientsPerMeal(string date);
    }
}
