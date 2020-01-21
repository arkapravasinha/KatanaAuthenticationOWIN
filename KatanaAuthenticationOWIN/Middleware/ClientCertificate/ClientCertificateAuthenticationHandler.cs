using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.IdentityModel.Claims;
using System.IdentityModel;
using Thinktecture.IdentityModel;


namespace KatanaAuthenticationOWIN.Middleware.ClientCertificate
{
    public class ClientCertificateAuthenticationHandler : AuthenticationHandler<ClientCertificateAuthenticationOptions>
    {
        protected override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            var cert = Context.Get<X509Certificate2>("ssl.ClientCertificate");

            if (cert==null)
            {
                return Task.FromResult<AuthenticationTicket>(null);
            }

            try
            {
                Options.Validator.Validate(cert);
                
            }
            catch (SecurityTokenValidationException)
            {
                return Task.FromResult<AuthenticationTicket>(null);
            }

           

            var identity = Identity.CreateFromCertificate(
                            cert,Options.AuthenticationType,Options.CreatedExtendedClaimSet);

            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());

            return Task.FromResult<AuthenticationTicket>(ticket);
        }
    }   
}