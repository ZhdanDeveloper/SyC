using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SyC.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LasttName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [ForeignKey("UserId")]
        public int UserId{ get; set; }
        public User user { get; set; }



    }
}
