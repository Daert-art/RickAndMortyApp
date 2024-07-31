﻿using RickAndMortyApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = RickAndMortyApp.Domain.Entity.Location;

namespace RickAndMortyApp.Data.Model
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status {  get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public Origin? Origin { get; set; }
        public Location? Location { get; set; }
        public string? Image { get; set; }
        public List<string>? Episode { get; set; }

        public CharacterModel()
        {

        }
        public CharacterModel(int id, string? name, string? status, string? species,
            string? type, string? gender, Origin? origin, Location? location, string? image, List<string>? episode)
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
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Status: {Status}, Species: {Species}, Type: {Type}, " +
                $"Gender: {Gender}, Origin: {Origin}, Location: {Location}, Image: {Image}, Episode: {Episode}";
        }

    }
}
