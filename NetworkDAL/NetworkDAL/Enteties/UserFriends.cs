using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetworkDAL.Enteties
{
    public class UserFriends : BaseEntity
    {
        public virtual UserProfile User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual UserProfile Friend { get; set; }
        [ForeignKey("Friend")]
        public int? FriendId { get; set; }
    }
}
