using Newtonsoft.Json.Linq;
using RickAndMortyApp.Data.Model;

namespace RickAndMortyApp.Data.Source.Remote.Api
{
    public class ApiProvider
    {
        private RickAndMortyApiScheme _rickAndMortyApiScheme { get; set; }
        HttpClient _httpClient = new HttpClient();
        public ApiProvider()
        {
            _rickAndMortyApiScheme = new RickAndMortyApiScheme();
        }
        public ApiProvider(RickAndMortyApiScheme rickAndMortyApiScheme)
        {
            _rickAndMortyApiScheme = rickAndMortyApiScheme;
        }
        public async Task<List<CharacterModel?>> GetCharactersEndPoint(int page)
        {
            try
            {
                //Get the request URL
                string requestUrl = _rickAndMortyApiScheme.GetCharacters(page);
                //Request Get Method to the API
                using HttpResponseMessage response = _httpClient.GetAsync(requestUrl).Result;
                //Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    //Get the response content
                    string content = await response.Content.ReadAsStringAsync();
                    //Parse the content to a JSON Object
                    JObject json = JObject.Parse(content);
                    //Get the results from the JSON Object
                    JArray results = (JArray)json["results"];
                    List<CharacterModel?> characterModels = new List<CharacterModel?>();
                    //Iterate over the results
                    if (results == null)
                    {
                        throw new Exception("Results is null");
                    }
                    else
                    {
                        foreach (var result in results)
                        {
                            CharacterModel? characterModel = result.ToObject<CharacterModel>();
                            characterModels.Add(characterModel);
                        }
                        return characterModels;
                    }
                }
                else
                {
                    throw new Exception("Error: " + response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<CharacterModel> GetCharacter(int id)
        {
            try
            {
                string requestUrl = _rickAndMortyApiScheme.GetCharacterById(id);
                using HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);

                    // Проверка, содержит ли ответ объект, а не массив
                    if (json["results"] != null)
                    {
                        JArray results = (JArray)json["results"];
                        if (results.Count > 0)
                        {
                            return results[0].ToObject<CharacterModel>();
                        }
                    }
                    else
                    {
                        return json.ToObject<CharacterModel>();
                    }

                    throw new Exception("Character not found in the results.");
                }
                else
                {
                    throw new Exception("Error: " + response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
