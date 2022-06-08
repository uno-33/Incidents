using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IncidentsDL.Entites
{
    public class Contact
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Account Account { get; set; }
    }
}
