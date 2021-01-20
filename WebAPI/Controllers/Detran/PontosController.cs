using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorPontosService _DetranVerificadorPontosServices;

        public PontosController(IMapper mapper, IDetranVerificadorPontosService detranVerificadorPontosServices)
        {
            _Mapper = mapper;
            _DetranVerificadorPontosServices = detranVerificadorPontosServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<CNHModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery]CNHModel model)
        {
            var pontos = await _DetranVerificadorPontosServices.ConsultarPontos(_Mapper.Map<CNH>(model));

            var result = new SuccessResultModel<IEnumerable<PontoCNHModel>>(_Mapper.Map<IEnumerable<PontoCNHModel>>(pontos));

            return Ok(result);
        }
    }
}