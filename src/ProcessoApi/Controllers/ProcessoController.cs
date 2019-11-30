using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProcessoApi.Models;
using ProcessoApi.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ProcessoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoRepository _repository;
        public ProcessoController(IProcessoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("numero_processo/{id}")]
        public IActionResult GetByCodigo(string id)
        {
            DadosProcesso processo = _repository.BuscaPorCodigo(id);

            if (processo != null)
                return StatusCode((int)HttpStatusCode.OK, new Envelpe(processo));
            else
                return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpGet("lista_processos")]
        public IActionResult Get()
        {
            List<DadosProcesso> processos = _repository.ListaProcessos();

            if (processos.Any())
                return StatusCode((int)HttpStatusCode.OK, new Envelpe(processos));
            else
                return StatusCode((int)HttpStatusCode.NoContent);
        }


        //[HttpGet("cliente/{id}")]
        //public IActionResult Get(string id)
        //{
        //    var processos = new List<DadosProcesso>();
        //    if (id.Length == 14)
        //        processos = _repository.BuscaPorCnpj(id);
        //    else if (id.Length == 11)
        //        processos = _repository.BuscaPorCpf(id);

        //    if (processos.Any())
        //        return StatusCode((int)HttpStatusCode.OK, new Envelpe(processos));
        //    else
        //        return StatusCode((int)HttpStatusCode.NoContent);
        //}

        [HttpPost("inserir")]
        public IActionResult Post()
        {
            var bodyStream = new StreamReader(Request.Body);

            string file = bodyStream.ReadToEnd();
            List<string> processos = file.Split(Environment.NewLine).ToList();
            List<DadosProcesso> processosInseridos = _repository.Inseri(processos);

            return StatusCode((int)HttpStatusCode.Created, new Envelpe(processosInseridos));
        }
    }
}
