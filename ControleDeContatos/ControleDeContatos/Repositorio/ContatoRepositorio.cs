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

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.ID == id);
        }


        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.ID);
            if (contatoDb == null) throw new System.Exception("Houve um erro de atualização");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;
        }



        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null) throw new System.Exception("Houve um erro de Exclusão");
            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}