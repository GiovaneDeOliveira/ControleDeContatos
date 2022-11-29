using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Data.Entity.Infrastructure;

namespace ControleDeContatos.Repositorio
{
    //como estou impementando (usando) sou obirgado a assinar este contrato
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            return contato;

        }
    }
}