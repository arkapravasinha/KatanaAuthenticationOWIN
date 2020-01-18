using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace KatanaAuthenticationOWIN.Middleware.BasicAuthentication
{
    public class BasicAuthenticationOptions: AuthenticationOptions
    {
        public BasicAuthenticationMiddleware.CredentialValidationFunction CredentialValidationFunction { get; private set; }

        public string Realm { get; set; }

        public BasicAuthenticationOptions(string realm,BasicAuthenticationMiddleware.CredentialValidationFunction credentialValidationFunction):base("basic")
        {
            Realm = realm;
            CredentialValidationFunction = credentialValidationFunction;
        }
    }

}