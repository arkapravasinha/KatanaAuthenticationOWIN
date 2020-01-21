using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.RequireTLS
{
    public static class RequireTlsExtension
    {
        public static IAppBuilder UseRequireTls(this IAppBuilder appBuilder,bool requireTls=false)
        {
            appBuilder.Use(typeof(RequireTlsMiddleware), new RequireTlsOptions { RequireClientCertificate=requireTls});
            return appBuilder;
        }
    }
}