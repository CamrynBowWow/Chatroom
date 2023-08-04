using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.CoreModel
{
    public class User
    {
        public Guid UsrId { get; set; } // Must fix or figure out how to use for db

        public string? FirstName { get; set; }   

        public string? LastName { get; set; }

        [Required]
        public string? UnquieName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Email { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? LastUpdatedAt { get; } = DateTime.Now;
    }
}
