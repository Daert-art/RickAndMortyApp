using RickAndMortyApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyApp.Domain.Entity
{
    public class Origin
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Url { get; set; }
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
        public List<string> Episode { get; set; }

        public CharacterEntity(int id, string name, string status, string species,
            string type, string gender, Origin origin, Location location, string image, List<string> episode)
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
            this.Id = characterModel.Id;
            this.Name = characterModel.Name ?? "No Name";
            this.Status = characterModel.Status ?? "No Status";
            this.Species = characterModel.Species ?? "No Species";
            this.Type = characterModel.Type ?? "No Type";
            this.Gender = characterModel.Gender ?? "No Gender";
            this.Origin = characterModel.Origin != null ? new Origin
            {
                Name = characterModel.Origin.Name ?? "No Origin Name",
                Url = characterModel.Origin.Url ?? "No Origin URL"
            } : new Origin { Name = "No Origin Name", Url = "No Origin URL" };
            this.Location = characterModel.Location != null ? new Location
            {
                Name = characterModel.Location.Name ?? "No Location Name",
                Url = characterModel.Location.Url ?? "No Location URL"
            } : new Location { Name = "No Location Name", Url = "No Location URL" };

            this.Image = characterModel.Image ?? "No Image";
            this.Episode = characterModel.Episode ?? new List<string> { "No Episode" };

        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Status: {Status}, Species: {Species}, Type: {Type}, " +
                $"Gender: {Gender}, Origin: {Origin}, Location: {Location}, Image: {Image}, Episode: {Episode}";
        }

    }
}
