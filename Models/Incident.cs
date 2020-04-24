using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeltaEndpoint.Models
{
    public partial class Incident
    {
        public int IncidentId { get; set; }

        [Phone]
        [Required]
        public long CreatorContact { get; set; }

        [Required]
        public string IssueType { get; set; }

        [Required]
        public string Location { get; set; }

         public string Status { get; set; }

        [Required]
        public byte[] Media { get; set; }

       
    }
}
