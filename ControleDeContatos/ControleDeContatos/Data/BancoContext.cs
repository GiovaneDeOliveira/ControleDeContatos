using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        //Construtor
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        //Definir os DbSet - Configurar as tabelas (entidades)
        //Classe ContatoModel servirá de base

        public DbSet<ContatoModel> Contatos { get; set; }


    }
}
