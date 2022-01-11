using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetworkDAL.Enteties
{
    /// <summary>
    /// Class for representing of friendship
    /// </summary>
    public class UserFriends
    {
        public virtual UserProfile User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual UserProfile Friend { get; set; }
        [ForeignKey("Friend")]
        public int? FriendId { get; set; }

        /// <summary>
        /// Represent if user accept the application for friendship
        /// </summary>
        public bool IsConfirmed { get; set; }
    }
}
