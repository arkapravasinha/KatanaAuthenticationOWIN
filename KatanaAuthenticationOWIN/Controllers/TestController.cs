using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaAuthenticationOWIN.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            var data = from c in claimsPrincipal.Claims
                       select c.Value;
            return Ok(data);
        }
    }
}
