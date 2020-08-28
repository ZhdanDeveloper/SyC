using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SyC.Entity
{
    public class User
    {

        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(50)]
        public string Name { get; set; }
        [Required, MinLength(6), MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        IEnumerable<Contact> Contacts { get; set; }

    }
}
