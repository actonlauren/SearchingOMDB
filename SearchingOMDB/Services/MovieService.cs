namespace SearchingOMDB.Services
{
    public class MovieService
    {
        private readonly HttpClient _client;

        public MovieService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetMovieInfo()
        {
            var httpResponseMessage = await _client.GetAsync("/?i=tt3896198&apikey=6bc4999");
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
