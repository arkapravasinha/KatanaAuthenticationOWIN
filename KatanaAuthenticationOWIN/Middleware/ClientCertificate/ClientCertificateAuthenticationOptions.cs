using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;

namespace KatanaAuthenticationOWIN.Middleware.ClientCertificate
{
    public class ClientCertificateAuthenticationOptions: AuthenticationOptions
    {
        public X509CertificateValidator Validator { get; set; }
        public bool CreatedExtendedClaimSet { get; set; }
        public ClientCertificateAuthenticationOptions():base("X.509")
        {
            Validator = X509CertificateValidator.ChainTrust;
            CreatedExtendedClaimSet = false;
        }
    }
}