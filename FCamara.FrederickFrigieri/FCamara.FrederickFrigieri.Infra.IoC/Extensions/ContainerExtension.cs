using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using SimpleInjector;

namespace FCamara.FrederickFrigieri.Infra.IoC.Extensions
{
    public static class ContainerExtension
    {
        //Esta extensão permite que que seja registrado um lote através de um assembly e namespace.
        //Com isso, precisamos apontar apenas o caminho do da classe concreta e o assembly em que ela está.
        public static void BatchRegister(this Container container, Assembly assembly, string nameSpace, [Optional]Lifestyle lifestyle)
        {
            //Funcionalidade retirada do próprio site do SimpleInjector.
            //Apenas foi adaptada para trabalhar com mais facilidade na nossa ferramenta.
            //https://simpleinjector.readthedocs.org/en/latest/advanced.html?highlight=automatic%20register#batch-registration

            //Consulta todas as classes e interfaces para registrar no container:
            var registrations =
                from type in assembly.GetExportedTypes()
                where type.Namespace == nameSpace
                //where type.GetInterfaces().Any()
                where type.GetInterface(string.Format("I{0}", type.Name)) != null
                select new { Service = type.GetInterface(string.Format("I{0}", type.Name)), Implementation = type };

            //Registrar no container todas as classes encontradas:

            if (lifestyle == null)
                foreach (var reg in registrations)
                    container.Register(reg.Service, reg.Implementation);
            else
                foreach (var reg in registrations)
                    container.Register(reg.Service, reg.Implementation, lifestyle);
        }

        //Esta extensão automatiza a funcionalidade RegisterBatch, pois
        // basta passar um tipo base que automaticamente vai buscar os outros dentro do mesmo assembly e mesmo namespace.
        public static void BatchRegister<TService>(this Container container, [Optional]Lifestyle lifestyle)
            where TService : class
        {
            var type = typeof(TService);
            container.BatchRegister(type.Assembly, type.Namespace, lifestyle);
        }
    }
}
