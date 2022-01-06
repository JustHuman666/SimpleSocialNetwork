using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.JvtAuthOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "here will be server"; 
        public const string AUDIENCE = "here will be client"; 
        const string KEY = "here will be token";   
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
