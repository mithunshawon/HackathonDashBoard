using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HackathonDashboard.Models;

namespace HackathonDashboard.Controllers.API
{
    [Authorize]
    public class TeamsController : ApiController
    {
        private HackathonDashboardContext db = new HackathonDashboardContext();

        // GET: api/Teams
        [Route("api/getTeams")]
        //[HttpGet]
        public List<Team> GetTeams()
        {
            var data = db.Teams.Where(x=>x.TeamId!="0").Select(t => t).ToList();
            return data;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        [Route("api/getTeam/{id}")]
        public IHttpActionResult GetTeam(string id)
        {
            Team temp = db.Teams.Find(id);
            var members = temp.Members.OrderBy(x => x.MemberName).ToList();
            Team team = new Team
            {
                Members = members,
                TeamId = temp.TeamId,
                TeamName = temp.TeamName,
                TeamLeaderName = temp.TeamLeaderName,
                Milestones = temp.Milestones
            };
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeam(string id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamId)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public IHttpActionResult PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TeamExists(team.TeamId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = team.TeamId }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult DeleteTeam(string id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();

            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(string id)
        {
            return db.Teams.Count(e => e.TeamId == id) > 0;
        }


        //[Route("api/editTeamMilestone/{teamId}/{milestone}")]
        //[ResponseType(typeof(void))]
        //[HttpPut]
        //public IHttpActionResult EditTeamMilestone(string teamId, Milestone milestone)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //db.Entry(team).State = EntityState.Modified;

        //    try
        //    {
        //        db.Teams.Where(t => t.TeamId == teamId).Select(x => x.Milestones).ToList().Where(a=>a.)
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeamExists(teamId))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
    }
}