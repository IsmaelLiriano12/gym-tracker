using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerShared.Data
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly GymTrackerDbContext context;

        public IngredientsRepository(GymTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<Ingredient> GetIngredientAsync(int id)
        {
            return await context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Dictionary<Meal, List<Ingredient>>> GetIngredientsPerMeal(string date)
        {
            var dateTime = GetDateTime(date);

            var ingredients = await context.Ingredients.Where(i => i.CreationDate == dateTime).ToListAsync();

            return SortIngredientsPerMeal(ingredients);
        }

        private static DateTime GetDateTime(string date)
        {
            DateTime dateTime;

            if (string.IsNullOrEmpty(date))
                dateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            else
                dateTime = Convert.ToDateTime(date);
            return dateTime;
        }

        private Dictionary<Meal, List<Ingredient>> SortIngredientsPerMeal(List<Ingredient> ingredients)
        {
            var meals = new Dictionary<Meal, List<Ingredient>>();

            foreach (var ingredient in ingredients)
            {
                if (!meals.ContainsKey(ingredient.Meal))
                    meals.Add(ingredient.Meal, new List<Ingredient> { ingredient });
                else
                    meals[ingredient.Meal].Add(ingredient);
            }

            return meals;
        }

        public void Add(Ingredient entity)
        {
            context.Ingredients.Add(entity);
        }

        public void Delete(Ingredient entity)
        {
            context.Ingredients.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;   
        }

        public void Update(Ingredient entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
