using SGL.BIBLIOTECA.ConsoleApp.Models;


while (true)
{
    Console.Clear ( );
    Cabecalho ( );

    Console.WriteLine ( "          Escolha uma opcão          " );
    Console.WriteLine ( "-------------------------------------\n" );
    Console.WriteLine ( "1 - Empréstimos e Devoluções" );
    Console.WriteLine ( "2 - Menu de Usuários" );
    Console.WriteLine ( "3 - Menu de livros" );
    Console.WriteLine ( "4 - Sair" );
    var opcao = Console.ReadLine ( );

    switch (opcao)
    {
        case "1":
            Teste ( );
            Pausa ( );
            break;

        case "2":
            Teste ( );
            Pausa ( );
            break;

        case "3":
            MenuLivraria ( );
            Pausa ( );
            break;

        case "4":
            return;

        default:
            Console.WriteLine ( "Opção inválida!" );
            Pausa ( );
            break;
    }
}

static void MenuLivraria( )
{
    Acervo acervo = new Acervo ();

    while (true)
    {
        Console.Clear ( );
        acervo.LerArquivo ( );
        Cabecalho ( );
        MenuLivro ( );
        var opcao = Console.ReadLine ( );

        switch (opcao)
        {
            case "1":
                acervo.AdicionarLivro ( );
                break;

            case "2":
                acervo.ExibirLivros ( );
                Pausa ( );
                break;

            case "3":
                acervo.LocalizarLivroTitulo ( );
                Pausa ( );
                break;

            case "4":
                acervo.LocalizarLivroAutor ( );
                Pausa ( );
                break;

            case "5":
                acervo.DeletarLivro ( );
                Pausa ( );
                break;

            case "6":
                acervo.AtivarLivro ( );
                Pausa ( );
                break;

            case "7":
                return;

            default:
                Console.WriteLine ( "Opção inválida!" );
                Pausa ( );
                break;
        }
    }
}

static void Cabecalho ( )
{
    Console.Clear ( );
    Console.WriteLine ( "SISTEMA DE GERENCIAMENTO DE BIBLIOTECA" );
    Console.WriteLine ( "--------------------------------------\n" );
}

static void MenuLivro ( )
{
    Console.WriteLine ( "          Escolha uma opcão          " );
    Console.WriteLine ( "-------------------------------------\n" );
    Console.WriteLine ( "1 - Adicionar um Livro" );
    Console.WriteLine ( "2 - Listar todos os livros" );
    Console.WriteLine ( "3 - Localizar livro pelo título" );
    Console.WriteLine ( "4 - Localizar livro pelo autor" );
    Console.WriteLine ( "5 - Desativar um livro" );
    Console.WriteLine ( "6 - Ativar livro" );
    Console.WriteLine ( "7 - Voltar para o menu anterior" );
}

static void Pausa ( )
{
    Console.WriteLine ( "\nTecle ENTER para continuar..." );
    Console.ReadLine ( );
}

static void Teste ( )
{
    Console.WriteLine ( "Link Funcionando" );
}