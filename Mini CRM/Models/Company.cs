using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM.Models
{
    [Table("company_table")]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required, StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string Responsible { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }

    }
}
