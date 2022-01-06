using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.EntetiesDto
{
    /// <summary>
    /// Class that represents a chat between two or more users
    /// </summary>
    public class ChatDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string ChatName { get; set; }

        public virtual ICollection<int> UserIds { get; set; }

        public virtual ICollection<int> MessageIds { get; set; }

    }
}
