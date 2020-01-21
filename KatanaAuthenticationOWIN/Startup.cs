using KatanaAuthenticationOWIN.Middleware.BasicAuthentication;
using KatanaAuthenticationOWIN.Middleware.ClientCertificate;
using KatanaAuthenticationOWIN.Middleware.RequireTLS;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

[assembly:OwinStartup(typeof(KatanaAuthenticationOWIN.Startup))]
namespace KatanaAuthenticationOWIN
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseRequireTls(requireTls: true);
            appBuilder.UseBasicAuthentication("Demo", ValidateUsers);
            appBuilder.UseClientCertificateAuthentication(X509RevocationMode.NoCheck,true);
           
        }

        private async Task<IEnumerable<Claim>> ValidateUsers(string id, string secret)
        {
            if (id == secret)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Role, "foo")
                };

                return await Task.FromResult<IEnumerable<Claim>>(claims);
            }

            return await Task.FromResult<IEnumerable<Claim>>(null);
        }
    }
}