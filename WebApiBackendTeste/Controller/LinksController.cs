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
using WebApiBackendTeste.Context;
using WebApiBackendTeste.HateOAS;

namespace WebApiBackendTeste.Controller
{
    public class LinksController : ApiController
    {
        private ContextModel db = new ContextModel();

        // GET: api/Links
        public IQueryable<Link> GetLink()
        {
            return db.Link;
        }

        // GET: api/Links/5
        [ResponseType(typeof(Link))]
        public IHttpActionResult GetLink(int id)
        {
            Link link = db.Link.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        // PUT: api/Links/5
        [ResponseType(typeof(void))]      

        // POST: api/Links
        [ResponseType(typeof(Link))]
        public IHttpActionResult PostLink(Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Link.Add(link);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = link.Id }, link);
        }

        // DELETE: api/Links/5
        [ResponseType(typeof(Link))]
        public IHttpActionResult DeleteLink(int id)
        {
            Link link = db.Link.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            db.Link.Remove(link);
            db.SaveChanges();

            return Ok(link);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}