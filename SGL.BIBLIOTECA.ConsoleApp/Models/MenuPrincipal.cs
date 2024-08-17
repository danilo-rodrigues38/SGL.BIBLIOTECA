using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class MenuPrincipal
    {
        private readonly EmprestimoManager _emprestimoManager;
        private readonly UsuarioManager _usuarioManager;
        private readonly Acervo _acervo;

        public MenuPrincipal()
        {
            _emprestimoManager = new EmprestimoManager();
            _usuarioManager = new UsuarioManager();
            _acervo = new Acervo();
        }

        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Cabecalho();

                ExibirOpcoesMenuPrincipal();
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        new MenuEmprestimoDevolucao(_emprestimoManager).Executar();
                        break;
                    case "2":
                        new MenuUsuario(_usuarioManager).Executar();
                        break;
                    case "3":
                        new MenuLivraria(_acervo).Executar();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Pausa();
                        break;
                }
            }
        }

        private void ExibirOpcoesMenuPrincipal()
        {
            Console.WriteLine("          Escolha uma opção          ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1 - Empréstimos e Devoluções");
            Console.WriteLine("2 - Menu de Usuários");
            Console.WriteLine("3 - Menu de livros");
            Console.WriteLine("4 - Sair");
        }

        protected static void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA");
            Console.WriteLine("--------------------------------------\n");
        }

        protected static void Pausa()
        {
            Console.WriteLine("\nTecle ENTER para continuar...");
            Console.ReadLine();
        }
    }
}