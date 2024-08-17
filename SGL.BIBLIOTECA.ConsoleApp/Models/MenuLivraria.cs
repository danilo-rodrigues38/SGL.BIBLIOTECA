using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class MenuLivraria : MenuBase
{
    private readonly Acervo _acervo;

    public MenuLivraria(Acervo acervo)
    {
        _acervo = acervo;
        _acervo.LerArquivo();
    }

    protected override void ExibirOpcoes()
    {
        Console.WriteLine("          Escolha uma opção          ");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("1 - Adicionar um Livro");
        Console.WriteLine("2 - Listar todos os livros");
        Console.WriteLine("3 - Localizar livro pelo título");
        Console.WriteLine("4 - Localizar livro pelo autor");
        Console.WriteLine("5 - Desativar um livro");
        Console.WriteLine("6 - Ativar livro");
        Console.WriteLine("0 - Voltar para o menu anterior");
    }

    protected override void ExecutarOpcao(string opcao)
    {
        switch (opcao)
        {
            case "1":
                AdicionarLivro();
                break;
            case "2":
                ListarLivros();
                break;
            case "3":
                LocalizarLivroPorTitulo();
                break;
            case "4":
                LocalizarLivroPorAutor();
                break;
            case "5":
                DesativarLivro();
                break;
            case "6":
                AtivarLivro();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                Pausa();
                break;
        }
    }

    private void AdicionarLivro()
    {
        try
        {
            _acervo.AdicionarLivro();
            Console.WriteLine("Livro adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao adicionar livro: {ex.Message}");
        }
        finally
        {
            Pausa();
        }
    }

    private void ListarLivros()
    {
        _acervo.ExibirLivros();
        Pausa();
    }

    private void LocalizarLivroPorTitulo()
    {
        try
        {
            _acervo.LocalizarLivroTitulo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao localizar livro: {ex.Message}");
        }
        finally
        {
            Pausa();
        }
    }

    private void LocalizarLivroPorAutor()
    {
        try
        {
            _acervo.LocalizarLivroAutor();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao localizar livro: {ex.Message}");
        }
        finally
        {
            Pausa();
        }
    }

    private void DesativarLivro()
    {
        try
        {
            _acervo.DeletarLivro();
            Console.WriteLine("Livro desativado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao desativar livro: {ex.Message}");
        }
        finally
        {
            Pausa();
        }
    }

    private void AtivarLivro()
    {
        try
        {
            _acervo.AtivarLivro();
            Console.WriteLine("Livro ativado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ativar livro: {ex.Message}");
        }
        finally
        {
            Pausa();
        }
    }
}
}