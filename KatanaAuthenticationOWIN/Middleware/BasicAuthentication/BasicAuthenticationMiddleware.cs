using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.BasicAuthentication
{
    public class BasicAuthenticationMiddleware:AuthenticationMiddleware<BasicAuthenticationOptions>
    {
        public delegate Task<IEnumerable<Claim>> CredentialValidationFunction(string id, string secret);

        public BasicAuthenticationMiddleware(OwinMiddleware next,BasicAuthenticationOptions basicAuthenticationOptions)
            :base(next,basicAuthenticationOptions)
        {
                
        }

        protected override AuthenticationHandler<BasicAuthenticationOptions> CreateHandler()
        {
            return new BasicAuthenticationHandler(Options);
        }
    }
}