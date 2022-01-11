using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.EntetiesDto
{
    /// <summary>
    /// Class that represents a message from one user to another 
    /// </summary>
    public class MessageDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime SendingTime { get; set; }

        public int SenderId { get; set; }

        public int ChatId { get; set; }

        public bool Status { get; set; }

        public string OriginalSenderUserName { get; set; }

    }
}
