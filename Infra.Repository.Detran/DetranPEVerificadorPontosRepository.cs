using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranPEVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranPEVerificadorPontosRepository(ILogger<DetranPEVerificadorPontosRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<PontosCNH>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<PontosCNH>>(new List<PontosCNH>() { new PontosCNH() });
        }

        protected override Task<string> RealizarAcesso(CNH cnh)
        {
            Task.Delay(5000).Wait(); //Deixando o serviço mais lento para evidenciar o uso do CACHE.
            _Logger.LogDebug($"Consultando pontos da CNH Registro {cnh.Registro} para o estado de PE.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/PE");
        }
    }
}
