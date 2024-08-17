using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SGL.BIBLIOTECA.ConsoleApp.Models;
using System;

namespace SGL.BIBLIOTECA.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurar o contêiner de injeção de dependência
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Criar o provedor de serviços
            using (var serviceProvider = services.BuildServiceProvider())
            {
                try
                {
                    // Obter a instância de MenuPrincipal e executá-la
                    var menuPrincipal = serviceProvider.GetRequiredService<MenuPrincipal>();
                    menuPrincipal.Executar();
                }
                catch (Exception ex)
                {
                    // Log de qualquer exceção não tratada
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocorreu um erro não tratado");
                    Console.WriteLine("Ocorreu um erro inesperado. Por favor, contate o suporte.");
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Adicionar logging
            services.AddLogging(configure => configure.AddConsole());

            // Registrar as classes do seu sistema
            services.AddSingleton<Acervo>();
            services.AddSingleton<UsuarioManager>();
            services.AddSingleton<EmprestimoManager>();

            // Registrar os menus
            services.AddTransient<MenuPrincipal>();
            services.AddTransient<MenuLivraria>();
            services.AddTransient<MenuUsuario>();
            services.AddTransient<MenuEmprestimoDevolucao>();
        }
    }
}