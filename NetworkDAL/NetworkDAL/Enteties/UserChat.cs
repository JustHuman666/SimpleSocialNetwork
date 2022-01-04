using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetworkDAL.Enteties
{
    public class UserChat : BaseEntity
    {
        public virtual UserProfile User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual Chat Chat { get; set; }
        [ForeignKey("ChatId")]
        public int ChatId { get; set; }

    }
}
