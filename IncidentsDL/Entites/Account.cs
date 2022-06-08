using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IncidentsDL.Entites
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Incident Incident { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        
    }
}
