﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonDashboard.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentOwner{ get; set; }
        public string CommentDescription { get; set; }
        public virtual Post Post { get; set; }
    }
}