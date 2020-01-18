using KatanaAuthenticationOWIN.Middleware.BasicAuthentication;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

[assembly:OwinStartup(typeof(KatanaAuthenticationOWIN.Startup))]
namespace KatanaAuthenticationOWIN
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseBasicAuthentication("Demo",ValidateUsers);
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