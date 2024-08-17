using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class MenuUsuario : MenuBase
    {
        private readonly UsuarioManager _usuarioManager;

        public MenuUsuario(UsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
            _usuarioManager.LerArquivo();
        }

        protected override void ExibirOpcoes()
        {
            Console.WriteLine("          Escolha uma opção          ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1 - Adicionar usuário");
            Console.WriteLine("2 - Listar todos os usuários");
            Console.WriteLine("3 - Localizar usuário pelo nome");
            Console.WriteLine("4 - Localizar usuário pelo email");
            Console.WriteLine("5 - Desativar um usuário");
            Console.WriteLine("6 - Ativar um usuário");
            Console.WriteLine("0 - Voltar para o menu anterior");
        }

        protected override void ExecutarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    AdicionarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    LocalizarUsuarioPorNome();
                    break;
                case "4":
                    LocalizarUsuarioPorEmail();
                    break;
                case "5":
                    DesativarUsuario();
                    break;
                case "6":
                    AtivarUsuario();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Pausa();
                    break;
            }
        }

        private void AdicionarUsuario()
        {
            try
            {
                _usuarioManager.AdicionarUsuario();
                Console.WriteLine("Usuário adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar usuário: {ex.Message}");
            }
            finally
            {
                Pausa();
            }
        }

        private void ListarUsuarios()
        {
            try
            {
                _usuarioManager.ListarUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar usuários: {ex.Message}");
            }
            finally
            {
                Pausa();
            }
        }

        private void LocalizarUsuarioPorNome()
        {
            try
            {
                _usuarioManager.LocalizarUsuarioPeloNome();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao localizar usuário: {ex.Message}");
            }
            finally
            {
                Pausa();
            }
        }

        private void LocalizarUsuarioPorEmail()
        {
            try
            {
                _usuarioManager.LocalizarUsuarioPeloEmail();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao localizar usuário: {ex.Message}");
            }
            finally
            {
                Pausa();
            }
        }

        private void DesativarUsuario()
        {
            try
            {
                _usuarioManager.DesativarUsuario();
                Console.WriteLine("Usuário desativado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao desativar usuário: {ex.Message}");
            }
            finally
            {
                Pausa();
            }
        }

        private void AtivarUsuario()
        {
            try
            {
                _usuarioManager.AtivarUsuario();
                Console.WriteLine("Usuário ativado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ativar usuário: {ex.Message}");
            }
            finally
            {
                Pausa();
            }
        }
    }
}