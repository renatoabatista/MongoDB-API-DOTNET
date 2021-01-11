using API.Models;
using API.Data;
using API.Data.Collections;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        [HttpGet("{id:guid}")]
        public ActionResult ObterInfectado(Guid id)
        {
            var infectado = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(_ => _.Id == id)).ToList();

            return Ok(infectado);
        }

        [HttpPut("{id:guid}")]
        public ActionResult AtualizarInfectado(Guid id, [FromBody] InfectadoDto dto)
        {
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Id == id), Builders<Infectado>.Update.Set("sexo", dto.Sexo).Set("dataNascimento", dto.DataNascimento).Set("localizacao.0", dto.Longitude).Set("localizacao.1", dto.Latitude));

            return Ok("Infectado atualizado com sucesso");
        }

        [HttpDelete("{id:guid}")]
        public ActionResult DeletarInfectado(Guid id)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Id == id));

            return Ok("Infectado removido com sucesso");
        }
    }
}