using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkAPI.Models
{
    public class ChatModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Chat name should consits of from {2} to {0} characters", MinimumLength = 2)]
        public string ChatName { get; set; }

        [Required]
        public virtual ICollection<int> UserIds { get; set; }
    }
}
