using RickAndMortyApp.Data.Model;

namespace RickAndMortyApp.Domain.Entity
{
    public class Origin
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public override string ToString() => $"{Name}";
    }

    public class Location
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public override string ToString() => $"{Name}";
    }

    public class CharacterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public Origin Origin { get; set; }
        public Location Location { get; set; }
        public string Image { get; set; }
        public string Episode { get; set; } // Изменен тип на строку

        public CharacterEntity() { }

        public CharacterEntity(int id, string name, string status, string species,
            string type, string gender, Origin origin, Location location, string image, string episode)
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            Origin = origin;
            Location = location;
            Image = image;
            Episode = episode;
        }

        public CharacterEntity(CharacterModel characterModel)
        {
            Id = characterModel.Id;
            Name = characterModel.Name ?? "No Name";
            Status = characterModel.Status ?? "No Status";
            Species = characterModel.Species ?? "No Species";
            Type = characterModel.Type ?? "No Type";
            Gender = characterModel.Gender ?? "No Gender";
            Origin = characterModel.Origin != null ? new Origin
            {
                Name = characterModel.Origin.Name ?? "No Origin Name",
                Url = characterModel.Origin.Url ?? "No Origin URL"
            } : new Origin { Name = "No Origin Name", Url = "No Origin URL" };
            Location = characterModel.Location != null ? new Location
            {
                Name = characterModel.Location.Name ?? "No Location Name",
                Url = characterModel.Location.Url ?? "No Location URL"
            } : new Location { Name = "No Location Name", Url = "No Location URL" };
            Image = characterModel.Image ?? "No Image";
            Episode = characterModel.Episode != null && characterModel.Episode.Any() ? characterModel.Episode.First() : "No Episode";
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Status: {Status}, Species: {Species}, Type: {Type}, " +
                $"Gender: {Gender}, Origin: {Origin}, Location: {Location}, Image: {Image}, Episode: {Episode}";
        }
    }

}
