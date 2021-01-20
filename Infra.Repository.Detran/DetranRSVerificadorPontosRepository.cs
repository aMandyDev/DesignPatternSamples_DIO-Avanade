using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranRSVerificadorPontosRepository : IDetranVerificadorPontosRepository
    {
        private readonly ILogger _Logger;

        public DetranRSVerificadorPontosRepository(ILogger<DetranRSVerificadorPontosRepository> logger)
        {
            _Logger = logger;
        }
    
        public Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            _Logger.LogDebug($"Consultando pontos da CNH registro {cnh.Registro} para o estado de RS.");
            return Task.FromResult<IEnumerable<PontosCNH>>(new List<PontosCNH>() { new PontosCNH() });
        }
    }
}
