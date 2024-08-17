using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public abstract class MenuBase
    {
        protected abstract void ExibirOpcoes();
        protected abstract void ExecutarOpcao(string opcao);

        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Cabecalho();

                ExibirOpcoes();
                var opcao = Console.ReadLine();

                if (opcao == "0")
                    return;

                ExecutarOpcao(opcao);
            }
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