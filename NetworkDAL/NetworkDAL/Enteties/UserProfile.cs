using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetworkDAL.Enteties
{
    /// <summary>
    /// Class that represents a profile information about user
    /// </summary>    
    public class UserProfile
    {
        [ForeignKey("ApplicationUser")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public virtual ICollection<UserProfile> Friends { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual User AppUser { get; set; }
    }
}
