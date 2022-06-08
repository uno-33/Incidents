using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentsBL.Models
{
    public class ContactModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountModel Account { get; set; }
    }
}
