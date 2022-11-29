using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{

    public class ContatoController : Controller
    {
        //2 - criamos esta variavel para que ela carregue o contrato e faça o tratamento
        //dentro desta classe por isso private e readonly
        private readonly IContatoRepositorio _contatoRepositorio;

        // 1 - inserir uma injeção para o construtor do IcontatoRepositorio
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int ID)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(ID);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            //Injetar o contatoRepositorio
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");

        }



        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }


        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}