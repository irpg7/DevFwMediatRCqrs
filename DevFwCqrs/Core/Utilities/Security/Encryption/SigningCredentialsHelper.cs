using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey key)
        {
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        }

    }
}
