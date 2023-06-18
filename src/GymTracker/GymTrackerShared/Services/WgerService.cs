using GymTrackerShared.Models;
using GymTrackerShared.Models.WgerModels;
using GymTrackerShared.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GymTrackerShared.Services
{
    public class WgerService : IWgerService
    {
        private HttpClient _httpClient = new HttpClient(
            new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
            });

        public WgerService()
        {
            _httpClient.BaseAddress = new Uri("https://wger.de/api/v2/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<ExerciseBaseInfo> GetExerciseBaseInfoAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"exercisebaseinfo/{id}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<ExerciseBaseInfo>();
            }
        }

        public async Task<IEnumerable<ExerciseBaseInfo>> GetExerciseBaseInfoCollectionAsync(int? variations = null)
        {
            var limitQuery = "limit=900";
            var variationsQuery = $"variations={variations}";

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"exercisebaseinfo/?{(variations == null ? limitQuery : variationsQuery)}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<WgerCollection<IEnumerable<ExerciseBaseInfo>>>().Results;
            }
        }

        public async Task<IEnumerable<ExerciseBaseInfo>> GetExerciseBaseInfoSuggetionsAsync(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"exercise/search/?term={name}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();
                return await GetExerciseBaseInfoCollectionFromSuggestions(stream.ReadAndDeserializeFromJson<SuggestionsCollection<ExerciseSuggestionsResult>>());
            }
        }

        private async Task<IEnumerable<ExerciseBaseInfo>> GetExerciseBaseInfoCollectionFromSuggestions(
            SuggestionsCollection<ExerciseSuggestionsResult> suggestionsCollection)
        {
            var exerciseBaseInfoCollection = new List<ExerciseBaseInfo>();

            foreach (var suggestionResult in suggestionsCollection.Suggestions)
            {
                exerciseBaseInfoCollection.Add(await GetExerciseBaseInfoAsync(suggestionResult.Data.BaseId));
            }
            return exerciseBaseInfoCollection;
        }

        public async Task<IEnumerable<IngredientSuggestionResult>> GetIngredientSuggestionResultAsync(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"ingredient/search?term={name}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response =  await _httpClient.SendAsync(request);

            using(var stream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<SuggestionsCollection<IngredientSuggestionResult>>().Suggestions;
            }
        }

        public async Task<NutritionFacts> GetNutritionFactsAsync(int ingredientId, decimal amount)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"ingredient/{ingredientId}/get_values/?amount={amount}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<NutritionFacts>();
            }
        }
    }
}
