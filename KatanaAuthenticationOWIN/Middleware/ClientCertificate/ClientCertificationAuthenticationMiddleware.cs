using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.ClientCertificate
{
    public class ClientCertificationAuthenticationMiddleware : AuthenticationMiddleware<ClientCertificateAuthenticationOptions>
    {
        protected override AuthenticationHandler<ClientCertificateAuthenticationOptions> CreateHandler()
        {
            return new ClientCertificateAuthenticationHandler();
        }

        public ClientCertificationAuthenticationMiddleware(OwinMiddleware next,ClientCertificateAuthenticationOptions options):base(next,options)
        {

        }
    }
}