using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonDashboard.Models
{
    public class Member
    {
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string TeamId { get; set; }
        public Team Team { get; set; }

        public Member()
        {
            TeamId = "1";
        }
    }
}