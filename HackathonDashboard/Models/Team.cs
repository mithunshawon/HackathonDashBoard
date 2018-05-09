using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HackathonDashboard.Models
{
    public class Team
    {
        public Team()
        {
            this.Members = new List<Member>();
            this.Milestones = new List<Milestone>();
        }
        public string TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string TeamLeaderName { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Milestone> Milestones { get; set; }
    }
}