using Newtonsoft.Json;
using ProcessoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoApi.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly PostgreeContext _context;
        public ProcessoRepository(PostgreeContext context)
        {
            _context = context;
        }
        public DadosProcesso BuscaPorCodigo(string codigoProcesso)
        {
            DadosProcesso processo = _context.Processo.FirstOrDefault(x => x.CodigoProcesso == codigoProcesso);
            return processo;
        }

        public List<DadosProcesso> ListaProcessos()
        {
            List<DadosProcesso> processos = _context.Processo.ToList();

            return processos;
        }

        //public List<DadosProcesso> BuscaPorCpf(string cpf)
        //{
        //    List<DadosProcesso> processos = _context.Processo.Where(x => x.CpfCnpjAutor == cpf).ToList();
        //    return processos;
        //}

        //public List<DadosProcesso> BuscaPorCnpj(string cnpj)
        //{
        //    List<DadosProcesso> processos = _context.Processo.Where(x => x.CpfCnpjReu == cnpj).ToList();
        //    return processos;
        //}

        public List<DadosProcesso> Inseri(List<string> listaProcessos)
        {
            List<DadosProcesso> processos = new List<DadosProcesso>();

            listaProcessos = listaProcessos.Where(x => !string.IsNullOrEmpty(x.Trim())).ToList();
            foreach (var item in listaProcessos)
            {
                try
                {
                    var processo = JsonConvert.DeserializeObject<Processo>(item);
                    _context.Processo.Add(processo.Dados.FirstOrDefault());
                    _context.SaveChanges();

                    processos.Add(processo.Dados.FirstOrDefault());
                }
                catch(Exception ex)
                {
                }
            }
            return processos;
        }
    }
}
