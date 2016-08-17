using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace FCamara.FrederickFrigieri.DS.Api
{
    public class AuthorizationServerProvider 
        : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //toda vez que é feito uma requisição no servidor API ele cai neste Validated
            //ele valida o token em um cache do OAuth (não há necessidade de saber com o OAuth gerencia isso, 
            //ele só precisa gerenciar
            //se ele não for valido ou se não for passado ele vai para o segundo método.
            context.Validated();
        }

        //esse método vai ser responsável pela autentição
        //é necessário entender que nós viemos de uma origem e retornamos para uma origem
        //essas origens são externas, você vem do terra faz um requisição e retorna para uma outra origem

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Verifica se já existe esse header
            var header = context.OwinContext.Response.Headers.SingleOrDefault(h => h.Key == "Access-Control-Allow-Origin");

            if (header.Equals(default(KeyValuePair<string, string[]>)))
                //preciso manter sempre este cabeçalho
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //toda requisição que é feito é enviado um context
            //todo context é enviado um "user" e "password"
            //aqui eu posso ir buscar no banco, arquivos ou em outros lugares
            try
            {
                var usuario = context.UserName;
                var password = context.Password;

                //se os dados forem inválidos ele devolve um tipo e uma mensagem para o context
                if (usuario != "fred" || password != "fcamara")
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos.");
                    return;
                }

                //se os dados forem válidos ele vai criar um Identity do Asp.Net
                //primeira coisa é criar uma identidade
                //depois eu vou adicionar vários claims para esse identity
                //os claims servem para nomear os tipos destes claim
                //posso ter vários tipos de claim
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Aqui eu estou adicionando um claim do tipo Name e o valor dele será o valor de usuario.
                //Esse claim pode ser resgatado atraves do identity.User.
                //Posso criar o tipo que eu quiser pois ele aceita como parametro o tipo string
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario));

                //No dia-a-dia trabalhamos com roles que são os perfis dos usuarios
                var roles = new List<string>();

                roles.Add("User");

                foreach (var role in roles)
                {
                    //Adiciona os roles para esta identidade
                    //Feito isso eu tenho uma identidade e os seus Claims criados
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                //Feito tudo isso eu vou precisar de um Principal
                //Vai ser o Manager de nossa conexao
                //Será nosso usuário e seus perfis
                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());

                //Necessário adicionar isso pois é como ele usa para acessar essas informações no Controller
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
    }
}