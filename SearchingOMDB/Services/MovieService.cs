using SearchingOMDB.Models;

namespace SearchingOMDB.Services
{
    public class MovieService
    {
        private readonly HttpClient _client;

        public MovieService(HttpClient client)
        {
            _client = client;
        }

        public async Task<MovieViewModel> GetMovieInfo(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync($"?apikey=6bc4999&t={userInput}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movieInfo = await httpResponseMessage.Content.ReadFromJsonAsync<MovieViewModel>();

                return movieInfo;
            }
            else
            {
                throw new Exception("Error gathering information.");
            }

        }

    }
}
