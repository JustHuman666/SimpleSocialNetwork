using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.EntetiesDto
{
    /// <summary>
    /// Class that represents anformation about logged user
    /// </summary>
    public class LoginUserInfo
    {
        public string Token { get; }
        public string UserId { get; }

        public LoginUserInfo(string token, string id)
        {
            Token = token;
            UserId = id;
        }
    }
}
