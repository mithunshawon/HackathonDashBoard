using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HackathonDashboard.Models
{
    public class Milestone
    {
        public Milestone()
        {
            this.Status = "Initial";
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MilestoneId { get; set; }
        public string TeamId { get; set; }
        public string MilestoneDescription { get; set; }
        public string Status { get; set; }

        public Team Team { get; set; }
    }
}