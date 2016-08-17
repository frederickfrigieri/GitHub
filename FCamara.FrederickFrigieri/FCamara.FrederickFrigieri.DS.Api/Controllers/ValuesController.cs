using System.Web.Http;

namespace FCamara.FrederickFrigieri.DS.Api.Controllers
{

    public class ValuesController : ApiController
    {
        [Authorize()]
        public string Get()
        {
            return User.Identity.Name;
        }
    }
}
