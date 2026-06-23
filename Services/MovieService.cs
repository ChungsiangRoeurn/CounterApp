using CounterApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace CounterApp.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient = new();
        private const string ApiKey = "76ad5aee";

        public async Task<List<MovieModel>> SearchMovies(string keyword)
        {
            var url = $"http://www.omdbapi.com/?apikey={ApiKey}&s={keyword}";

            var result = await _httpClient.GetFromJsonAsync<OmdbResponse>(url);

            if (result?.Search == null)
                return new List<MovieModel>();

            return result.Search.Select(m => new MovieModel
            {
                Title = m.Title ?? "",
                Year = m.Year ?? "",
                PosterUrl = m.Poster == "N/A" ? "" : m.Poster,
                ImdbID = m.imdbID ?? ""
            }).ToList();
        }
    }
}