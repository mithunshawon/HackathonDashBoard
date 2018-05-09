using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonDashboard.Models
{
    public class Post
    {
        private DateTime? dateCreated = null;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string PostOwner { get; set; }
        public string Status { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileUrl { get; set; }
        public Byte[] Content { get; set; }
        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated.HasValue? this.dateCreated.Value: DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        
        //public DateTime PostCreated {
        //    get
        //    {
        //        return DateTime.Now;
        //    }
        //}

        public virtual ICollection<Comment> Comments { get; set; }
    }
}