using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkDAL.Enteties
{
    /// <summary>
    /// Class that represents a chat between two or more users
    /// </summary>
    public class Chat : BaseEntity
    {
        /// <summary>
        /// Date of creating of this chat
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Name of the chat
        /// </summary>
        public string ChatName { get; set; }

        /// <summary>
        /// Collection of all users who are in this chat
        /// </summary>
        public virtual ICollection<UserChat> Users {get; set;}

        /// <summary>
        /// Collection of all messages - history of the chat
        /// </summary>
        public virtual ICollection<Message> Messages { get; set; }

    }
}
