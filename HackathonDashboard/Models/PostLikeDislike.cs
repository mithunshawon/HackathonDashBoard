using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonDashboard.Models
{
    public class PostLikeDislike
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string MemberId { get; set; }
        public int NoOfLikes { get; set; }
    }
}