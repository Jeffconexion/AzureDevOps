using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.WebApp.Config
{
  public static class ConfiguracoesInjecaoDependencia
  {
    public static IServiceCollection AddDependenciasConfig(this IServiceCollection services)
    {
      services.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
      services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
      services.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

      return services;
    }

  }
}
