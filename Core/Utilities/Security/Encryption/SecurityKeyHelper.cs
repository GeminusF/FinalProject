using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {   //ASP.NETin JWT servicelerini basa duseceyi hala getiririk verddiyimiz keyleri
        public static SecurityKey CreateSecurityKey(string securityKey) 
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
