using System.Text;
using System.Text.Json;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices
{
    public class GraphQLSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public GraphQLSpaceXDataService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }


        public async Task<LaunchDto[]> GetAllLaunches()
        {
            var queryObj = new {
                query = @"{launches{id is_tentative mission_name launch_date_local}}",
                variables = new {}
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObj),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode)
            {
                var gqlData = await JsonSerializer.DeserializeAsync<GqlData>(
                    await response.Content.ReadAsStreamAsync()
                    );
                
                return gqlData.Data.Launches;
            }

            return null;
        }
    }
}