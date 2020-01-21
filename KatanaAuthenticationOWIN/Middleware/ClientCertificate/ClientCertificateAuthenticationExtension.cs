using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.ClientCertificate
{
    public static class ClientCertificateAuthenticationExtension
    {
        public static IAppBuilder UseClientCertificateAuthentication(this IAppBuilder appBuilder, X509RevocationMode revocationMode = X509RevocationMode.Online, bool extendedClaimSet = false)
        {
            var policy = new X509ChainPolicy {
                RevocationMode =revocationMode
            };

            var validator = X509CertificateValidator.CreateChainTrustValidator(true, policy);

            var options = new ClientCertificateAuthenticationOptions
            {
                CreatedExtendedClaimSet = extendedClaimSet,
                Validator=validator
            };

            return appBuilder.UseClientCertificateAuthentication(options);
        }

        public static IAppBuilder UseClientCertificateAuthentication(this IAppBuilder app,ClientCertificateAuthenticationOptions options)
        {
            app.Use<ClientCertificationAuthenticationMiddleware>(options);
            return app;
        }
    }
}