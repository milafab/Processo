using System.Collections.Generic;
using ProcessoApi.Models;

namespace ProcessoApi.Repository
{
    public interface IProcessoRepository
    {
        //List<DadosProcesso> BuscaPorCnpj(string cnpj);
        DadosProcesso BuscaPorCodigo(string codigoProcesso);
        List<DadosProcesso> ListaProcessos();
        //List<DadosProcesso> BuscaPorCpf(string cpf);
        List<DadosProcesso> Inseri(List<string> processos);
    }
}