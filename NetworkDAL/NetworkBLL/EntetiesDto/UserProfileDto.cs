using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.EntetiesDto
{
    /// <summary>
    /// Class that represents a profile information about user
    /// </summary>    
    public class UserProfileDto
    {
        
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<int> UserIsFriendIds { get; set; }

        public virtual ICollection<int> ThisUserFriendIds { get; set; }

        public virtual ICollection<int> ChatIds { get; set; }

        public virtual ICollection<int> MessageIds { get; set; }


    }
}
