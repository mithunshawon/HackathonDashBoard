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
    public class MembersController : ApiController
    {
        private HackathonDashboardContext db = new HackathonDashboardContext();

        // GET: api/Members
        public IQueryable<Member> GetMembers()
        {
            return db.Members;
        }

        // GET: api/Members/5
        [ResponseType(typeof(Member))]
        [Route("api/getMember/{id}")]
        public IHttpActionResult GetMember(string id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // GET: api/Members/emailID
        [ResponseType(typeof(Member))]
        [Route("api/getCurrentUser")]
        public IHttpActionResult GetMemberByEmail()
        {
            var index = User.Identity.Name.LastIndexOf('\\');
            var emailId = User.Identity.Name.Substring(index+1)+"@bd.imshealth.com";

            Member member = db.Members.Where(x=>x.MemberEmail.Equals(emailId,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMember(string id, Member member)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != member.MemberId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(member).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MemberExists(id))
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

        // POST: api/Members
        //[ResponseType(typeof(Member))]
        //public IHttpActionResult PostMember(Member member)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var memberCount = db.Members.Count();
        //    member.MemberId = "U" + (memberCount+1).ToString();

        //    db.Members.Add(member);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MemberExists(member.MemberId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = member.MemberId }, member);
        //}

        // DELETE: api/Members/5
        //[ResponseType(typeof(Member))]
        //public IHttpActionResult DeleteMember(string id)
        //{
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Members.Remove(member);
        //    db.SaveChanges();

        //    return Ok(member);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool MemberExists(string id)
        //{
        //    return db.Members.Count(e => e.MemberId == id) > 0;
        //}
    }
}