namespace RickAndMortyApp.Data.Source.Remote.Api
{
    public sealed class RickAndMortyApiScheme
    {
        //Base URL
        private const string BaseUrl = @"https://rickandmortyapi.com/api/";

        //Get all characters per page
        public string GetCharacters(int page)
        {
            return $"{BaseUrl}character/?page={page}";
        }
        //Get single character by Id
        public string GetCharacterById(int id)
        {
            return $"{BaseUrl}character/{id}";
        }

    }
}
