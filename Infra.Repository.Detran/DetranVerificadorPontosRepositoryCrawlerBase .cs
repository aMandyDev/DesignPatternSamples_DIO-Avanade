using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public abstract class DetranVerificadorPontosRepositoryCrawlerBase : IDetranVerificadorPontosRepository
    {
        public async Task<IEnumerable<PontosCNH>> ConsultarPontos(CNH cnh)
        {
            var html = await RealizarAcesso(cnh);
            return await PadronizarResultado(html);
        }

        protected abstract Task<string> RealizarAcesso(CNH cnh);
        protected abstract Task<IEnumerable<PontosCNH>> PadronizarResultado(string html);
    }
}
