using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using FCamara.FrederickFrigieri.Infra.IoC;
using SimpleInjector.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartup(typeof(FCamara.FrederickFrigieri.DS.Api.Startup))]

namespace FCamara.FrederickFrigieri.DS.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigurarRota(config);
            ConfigurarCors(app);
            ConfigurarOAuth(app);
            ConfigurarWebApi(config);
            ConfigurarIoC(config);

            app.UseWebApi(config);
        }

        public static void ConfigurarWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;

            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }


        public static void ConfigurarRota(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        public static void ConfigurarCors(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
        }

        public static void ConfigurarOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                //Permite requisições não seguras
                AllowInsecureHttp = true,
                //url de requisição do token (Responsabilidade do Owin)
                TokenEndpointPath = new PathString("/api/security/token"),
                //tempo que o token expira
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),
                //responsável por autenticação
                Provider = new AuthorizationServerProvider()
            };

            //digo para a aplicação qual as opções da autorização 
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        public static void ConfigurarIoC(HttpConfiguration config)
        {
            Container container = new Container();
            container.RegisterWebApiControllers(config);
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            container.Bootstrap(new WebApiRequestLifestyle(false));

            container.Verify();
        }
    }
}
