using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkDAL.Enteties
{
    /// <summary>
    /// Class that represents possible message status for helping user with more information
    /// </summary>
    public class MessageStatus : BaseEntity
    {
        public string StatusName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

    }
}
