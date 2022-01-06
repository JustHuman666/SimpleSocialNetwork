using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkBLL.EntetiesDto
{
    /// <summary>
    /// Class that represents possible message status for helping user with more information
    /// </summary>
    public class MessageStatusDto
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<int> MessageIds { get; set; }

    }
}
