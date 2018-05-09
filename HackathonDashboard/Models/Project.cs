using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonDashboard.Models
{
    public class Project
    {
        //[Key,ForeignKey("Team")]
        public string TeamId { get; set; }
        public string ProjectDescription { get; set; }
        public string TechnologyStack { get; set; }
        public virtual  Team Team { get; set; }
    }
}