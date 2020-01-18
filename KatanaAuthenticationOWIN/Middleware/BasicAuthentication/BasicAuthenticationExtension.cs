using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.BasicAuthentication
{
    public static class BasicAuthenticationExtension
    {
        public static IAppBuilder UseBasicAuthentication(this IAppBuilder appBuilder,string realm,BasicAuthenticationMiddleware.CredentialValidationFunction credentialValidationFunction)
        {
            var options = new BasicAuthenticationOptions(realm, credentialValidationFunction);
            return appBuilder.UseBasicAuthentication(options);
        }

        public static IAppBuilder UseBasicAuthentication(this IAppBuilder appBuilder,BasicAuthenticationOptions basicAuthenticationOptions)
        {
            return appBuilder.Use<BasicAuthenticationMiddleware>(basicAuthenticationOptions);
        }
    }

}