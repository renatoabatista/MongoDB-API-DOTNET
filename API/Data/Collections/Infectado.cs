using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            Id = Guid.NewGuid();
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        [BsonId]
        public Guid Id { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}
