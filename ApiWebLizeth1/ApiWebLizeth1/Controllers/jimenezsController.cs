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
using ApiWebLizeth1.Models;

namespace ApiWebLizeth1.Controllers
{
    public class jimenezsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/jimenezs
        [Authorize]
        public IQueryable<jimenez> Getjimenezs()
        {
            return db.jimenezs;
        }

        // GET: api/jimenezs/5
        [Authorize]
        [ResponseType(typeof(jimenez))]
        public IHttpActionResult Getjimenez(int id)
        {
            jimenez jimenez = db.jimenezs.Find(id);
            if (jimenez == null)
            {
                return NotFound();
            }

            return Ok(jimenez);
        }

        // PUT: api/jimenezs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putjimenez(int id, jimenez jimenez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jimenez.JimenezID)
            {
                return BadRequest();
            }

            db.Entry(jimenez).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jimenezExists(id))
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

        // POST: api/jimenezs
        [Authorize]
        [ResponseType(typeof(jimenez))]
        public IHttpActionResult Postjimenez(jimenez jimenez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.jimenezs.Add(jimenez);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jimenez.JimenezID }, jimenez);
        }

        // DELETE: api/jimenezs/5
        [Authorize]
        [ResponseType(typeof(jimenez))]
        public IHttpActionResult Deletejimenez(int id)
        {
            jimenez jimenez = db.jimenezs.Find(id);
            if (jimenez == null)
            {
                return NotFound();
            }

            db.jimenezs.Remove(jimenez);
            db.SaveChanges();

            return Ok(jimenez);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool jimenezExists(int id)
        {
            return db.jimenezs.Count(e => e.JimenezID == id) > 0;
        }
    }
}