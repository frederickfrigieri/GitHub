using FCamara.ProximaParada.Data.Repositories;
using FCamara.ProximaParada.Domain.Contracts.Repositories;
using FCamara.ProximaParada.Domain.Contracts.Services;
using FCamara.ProximaParada.Domain.Services;
using FCamara.ProximaParada.IOC.Adapters;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace FCamara.ProximaParada.IOC
{
    public static class Startup
    {
        public static void Bootstrap(this Container container, Lifestyle lifestyle)
        {
            container.Register<IAmigoRepository, AmigoRepository>(lifestyle);
            container.Register<IAmigoService, AmigoService>(lifestyle);
            

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
