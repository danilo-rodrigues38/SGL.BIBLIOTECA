using Newtonsoft.Json;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class UsuarioManager
    {
        string folder = "Gravadas";
        string fileName = "usuario.json";
        string path = "Gravadas\\usuario.json";
        string line;

        List<Usuario> usuarios = new List<Usuario>();

        public void AdicionarUsuario ( )
        {
            try
            {
                if (usuarios.Count == 0)
                {
                    Lerarquivo ( );
                }

                Console.Clear();
                Console.WriteLine ( "                  CADASTRO DE USUÁRIO                  " );
                Console.WriteLine ( "-------------------------------------------------------\n" );

                var id = usuarios.Count + 1;

                Console.Write ( "Digite o nome completo: " );
                var nome = Console.ReadLine ( );

                Console.Write ( "Digite o e-mail: " );
                var email = Console.ReadLine ( );

                var usuario = new Usuario( id, nome, email );

                usuarios.Add ( usuario );

                GravarArquivo ( );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void ListarUsuario ( )
        {
            try
            {
                Console.Clear ( );

                if ( usuarios.Count == 0)
                {
                    Lerarquivo ( );
                }

                Console.WriteLine ( "                    LISTA DE USUÁRIO                   " );
                Console.WriteLine ( "-------------------------------------------------------\n" );

                foreach (var usuario in usuarios)
                {
                    if ( usuario.Ativo == true )
                    {
                        usuario.DetalheUsuario ( );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void LocalizarUsuarioPeloNome ( )
        {
            Console.Clear ( );
            try
            {
                Console.Write ( "Digite o nome a ser localizado: " );
                var nomeUsuario = Console.ReadLine ( );

                var usuariosLocalizados = usuarios.Where(u => u.Nome.ToUpper().Contains (nomeUsuario.ToUpper()) && u.Ativo);

                foreach (var usuarioLocalizado in usuariosLocalizados)
                {
                    usuarioLocalizado.DetalheUsuario ( );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void LocalizarUsuarioPeloEmail ( )
        {
            Console.Clear ( );
            try
            {
                Console.Write ( "Digite o e-mail a ser localizado: " );
                var emailUsuario = Console.ReadLine ( );

                var emailUsuariosLocalizados = usuarios.Where(e => e.Email.ToLower().Contains (emailUsuario.ToLower()) && e.Ativo);

                foreach (var email in emailUsuariosLocalizados)
                {
                    email.DetalheUsuario ( );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void DesativarUsuario ( )
        {
            try
            {
                Console.Clear ( );
                Console.WriteLine ( "             DESATIVAR CADASTRO DE USUÁRIO             " );
                Console.WriteLine ( "-------------------------------------------------------\n" );
                Console.WriteLine ( "Digite o id do usuário a ser desativado: " );
                var idUsuarioDesativar = int.Parse ( Console.ReadLine () );

                if (usuarios.Any ( u => u.Id == idUsuarioDesativar ))
                {
                    usuarios [ idUsuarioDesativar - 1 ].Ativo = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }

            GravarArquivo ( );
        }

        public void AtivarUsuario ( )
        {
            Console.Clear ( );

            try
            {
                Console.WriteLine ( "               ATIVAR CADASTRO DE USUÁRIO              " );
                Console.WriteLine ( "-------------------------------------------------------\n" );

                ExibirUsuariosInativos ( );

                Console.WriteLine ( "Digite o id do usuário a ser desativado: " );
                var idUsuarioDesativar = int.Parse ( Console.ReadLine () );

                if (usuarios.Any ( u => u.Id == idUsuarioDesativar ))
                {
                    usuarios [ idUsuarioDesativar - 1 ].Ativo = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }

            GravarArquivo ( );
        }

        public void CriarArquivo ( )
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo ( folder );

                if (!di.Exists)
                {
                    Directory.CreateDirectory ( folder );
                }

                if (!File.Exists ( path ))
                {
                    File.WriteAllText ( path, string.Empty );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.ToString ( )}" );
            }
        }

        public void GravarArquivo ( )
        {
            try
            {
                CriarArquivo ( );

                string serializado = JsonConvert.SerializeObject ( usuarios, Formatting.Indented );

                File.WriteAllText( path, serializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.ToString ( )}" );
            }
        }

        public void Lerarquivo ( )
        {
            Console.Clear ( );
            try
            {
                string deserializado = File.ReadAllText ( path );

                usuarios = JsonConvert.DeserializeObject<List<Usuario>> ( deserializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.ToString ( )}" );
            }
        }

        private void ExibirUsuariosInativos ( )
        {
            Console.WriteLine ( "Listagem de usuários inativos" );

            foreach (var usuario in usuarios)
            {
                if (usuario.Ativo == false)
                {
                    usuario.DetalheUsuario ( );
                }
            }
        }
    }
}