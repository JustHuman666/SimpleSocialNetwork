﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetworkDAL.Enteties
{
    /// <summary>
    /// Class that represents a message from one user to another 
    /// </summary>
    public class Message : BaseEntity
    {
        /// <summary>
        /// The content of this message
        /// </summary>
        [Required]
        [MinLength(1)]
        public string Text { get; set; }

        /// <summary>
        /// Time of sending of this message
        /// </summary>
        [Required]
        public DateTime SendingTime {get; set;}

        /// <summary>
        /// Instance of user who send this message
        /// </summary>
        public virtual UserProfile Sender { get; set; }
        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        /// <summary>
        /// Instance of chat where this message was sent
        /// </summary>
        public virtual Chat UsersChat { get; set; }
        [ForeignKey("Chat")]
        public int ChatId { get; set; }

        /// <summary>
        /// Message status for users, true - if read, false - if only sent
        /// </summary>
        public virtual bool Status { get; set; }

        /// <summary>
        /// The user name of original sender of this message
        /// </summary>
        public string OriginalSenderUserName { get; set; }


    }
}
