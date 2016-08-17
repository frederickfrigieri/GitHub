using FCamara.FrederickFrigieri.Domain.Contracts.Repositories;
using FCamara.FrederickFrigieri.Domain.Contracts.Services;
using FCamara.FrederickFrigieri.Domain.Services;
using FCamara.FrederickFrigieri.Infra.Data.Contexts;
using FCamara.FrederickFrigieri.Infra.Data.Repositories;
using FCamara.FrederickFrigieri.Infra.IoC.Adapters;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using System.Data.Entity;

namespace FCamara.FrederickFrigieri.Infra.IoC
{
    public static class Startup
    {
        public static void Bootstrap(this Container container, Lifestyle lifestyle)
        {
            container.Register<IProdutoRepository,ProdutoRepository>();
            container.Register<IProdutoService, ProdutoService>();
            container.Register<Contexto>(lifestyle);

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
