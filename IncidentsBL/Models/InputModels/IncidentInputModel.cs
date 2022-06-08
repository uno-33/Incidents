using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IncidentsBL.Models.InputModels
{
    public class IncidentInputModel
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string ContactFirstName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string IncidentDescription { get; set; }
    }
}
