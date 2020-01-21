using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatanaAuthenticationOWIN.Middleware.RequireTLS
{
    public class RequireTlsOptions
    {
        public bool RequireClientCertificate { get; set; }
    }
}