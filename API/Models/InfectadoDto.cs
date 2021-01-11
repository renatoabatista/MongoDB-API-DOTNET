using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class InfectadoDto
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
