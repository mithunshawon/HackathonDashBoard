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
    public class MilestonesController : ApiController
    {
        private HackathonDashboardContext db = new HackathonDashboardContext();

        // GET: api/Milestones
        public IQueryable<Milestone> GetMilestones()
        {
            return db.Milestones;
        }

        // GET: api/Milestones/5
        [ResponseType(typeof(Milestone))]
        public IHttpActionResult GetMilestone(int id)
        {
            Milestone milestone = db.Milestones.Find(id);
            if (milestone == null)
            {
                return NotFound();
            }

            return Ok(milestone);
        }

        [HttpPut]
        // PUT: api/Milestones/5
        [ResponseType(typeof(void))]
        [Route("api/editMilestone/{id}")]
        public IHttpActionResult PutMilestone(int id, Milestone milestone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != milestone.MilestoneId)
            {
                return BadRequest();
            }

            db.Entry(milestone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilestoneExists(id))
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

        // POST: api/Milestones
        [ResponseType(typeof(Milestone))]
        [Route("api/postMilestone")]
        public IHttpActionResult PostMilestone(Milestone milestone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Milestones.Add(milestone);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = milestone.MilestoneId }, milestone);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Milestones/5
        [ResponseType(typeof(Milestone))]
        public IHttpActionResult DeleteMilestone(int id)
        {
            Milestone milestone = db.Milestones.Find(id);
            if (milestone == null)
            {
                return NotFound();
            }

            db.Milestones.Remove(milestone);
            db.SaveChanges();

            return Ok(milestone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MilestoneExists(int id)
        {
            return db.Milestones.Count(e => e.MilestoneId == id) > 0;
        }
    }
}