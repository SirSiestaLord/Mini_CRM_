using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_CRM.Models
{
    [Table("meetings_table")]
    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }

        public int CompanyId { get; set; }

        public DateTime MeetingDate { get; set; }
        public string MeetingNote { get; set; }
        public string MeetingType { get; set; }
        public DateTime? NextActionDate { get; set; }

        public virtual Company Company { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
