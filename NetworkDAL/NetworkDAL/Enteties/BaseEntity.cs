using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetworkDAL.Enteties
{
    /// <summary>
    /// Class that represents base entity with unique id
    /// </summary>
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
