using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.EntetiesDto
{
    /// <summary>
    /// Class that represents all information about user
    /// </summary>    
    public class UserDto
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual UserProfileDto UserProfile { get; set; }

    }
}
