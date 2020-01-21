using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.RequireTLS
{
    public class RequireTlsMiddleware
    {
        readonly Func<IDictionary<string,object>, Task> _next;
        private RequireTlsOptions _tlsOptions;

        public RequireTlsMiddleware(Func<IDictionary<string,object>,Task> next,RequireTlsOptions requireTlsOptions)
        {
            this._next = next;
            this._tlsOptions = requireTlsOptions;
        }

        public async Task Invoke(IDictionary<string,object> env)
        {
            var context = new OwinContext(env);

            if (context.Request.Uri.Scheme!=Uri.UriSchemeHttps)
            {
                context.Response.StatusCode = 403;
                context.Response.ReasonPhrase = "SSL is required";
                return;
            }

            if (_tlsOptions.RequireClientCertificate)
            {
                var cert = context.Get<X509Certificate2>("ssl.ClientCertificate");
                if (cert==null)
                {
                    context.Response.StatusCode = 403;
                    context.Response.ReasonPhrase = "SSL Client Certificate is required";
                    return;
                }
            }

            await _next(env);
        }

        
    }
}