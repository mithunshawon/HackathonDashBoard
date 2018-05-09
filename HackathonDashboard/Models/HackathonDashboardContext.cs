using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HackathonDashboard.Models
{
    public class HackathonDashboardContext:DbContext
    {
        public HackathonDashboardContext():base("CONTENT")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostLikeDislike> PostLikeDislikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure TeamId as PK for Projects
            modelBuilder.Entity<Project>().HasKey(p => p.TeamId);

            // Configure TeamId as FK for Projects
            modelBuilder.Entity<Project>().HasRequired(p => p.Team).WithOptional(x=>x.Project);

            modelBuilder.Entity<Member>().HasRequired<Team>(t => t.Team).WithMany(t => t.Members).HasForeignKey(t => t.TeamId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Milestone>().HasRequired<Team>(t => t.Team).WithMany(t => t.Milestones).HasForeignKey(t => t.TeamId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>().HasRequired<Post>(c => c.Post).WithMany(c => c.Comments).HasForeignKey(c => c.PostId)
                        .WillCascadeOnDelete(false);
        }

    }
}