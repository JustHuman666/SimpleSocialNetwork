using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkAPI.Models
{
    public class MessageModel
    {
        [Required]
        [MinLength(1)]
        public string Text { get; set; }

        public int SenderId { get; set; }

        [Required]
        public int ChatId { get; set; }

    }
}
