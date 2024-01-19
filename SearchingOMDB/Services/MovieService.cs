namespace SearchingOMDB.Services
{
    public class MovieService
    {
        private readonly HttpClient _client;

        public MovieService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetMovieInfo(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync("{userInput}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movieInfo = await httpResponseMessage.Content.ReadFromJsonAsync<MovieInfo>();

                return movieInfo.message;
            }
            else
            {
                throw new Exception("Error gathering information.");
            }

        }

    }
}
