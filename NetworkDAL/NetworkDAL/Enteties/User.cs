using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkDAL.Enteties
{

    /// <summary>
    /// Class that represents user in DB with user profile
    /// </summary>
    public class User : IdentityUser<int>
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
