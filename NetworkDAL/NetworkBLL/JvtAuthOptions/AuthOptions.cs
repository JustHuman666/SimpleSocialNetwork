using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.JvtAuthOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "http://localhost:44337"; 
        public const string AUDIENCE = "http://localhost:4200/"; 
        const string KEY = "skfhhsjayeudeyucbxbddxuwqydguwydcqdcwqudvw1261x6e";   
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
