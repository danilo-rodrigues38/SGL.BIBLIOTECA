using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class MenuEmprestimoDevolucao : MenuBase
    {
        private readonly EmprestimoManager _emprestimoManager;

        public MenuEmprestimoDevolucao(EmprestimoManager emprestimoManager)
        {
            _emprestimoManager = emprestimoManager;
        }

        protected override void ExibirOpcoes()
        {
            Console.WriteLine("          Escolha uma opção          ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1 - Emprestar um livro");
            Console.WriteLine("2 - Devolver um livro");
            Console.WriteLine("0 - Retornar ao menu anterior");
        }

        protected override void ExecutarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    _emprestimoManager.EmprestarLivro();
                    break;
                case "2":
                    _emprestimoManager.DevolverLivro();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Pausa();
                    break;
            }
        }
    }
}