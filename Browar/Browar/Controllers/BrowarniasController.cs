using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Browar.Models;

namespace Browar.Controllers
{
    public class BrowarniasController : ApiController
    {
        private BrowarContext db = new BrowarContext();

        // GET: api/Browarnias
        public IQueryable<Browarnia> GetBrowarnias()
        {
            return db.Browarnias;
        }

        // GET: api/Browarnias/5
        [ResponseType(typeof(Browarnia))]
        public async Task<IHttpActionResult> GetBrowarnia(int id)
        {
            Browarnia browarnia = await db.Browarnias.FindAsync(id);
            if (browarnia == null)
            {
                return NotFound();
            }

            return Ok(browarnia);
        }

        // PUT: api/Browarnias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBrowarnia(int id, Browarnia browarnia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != browarnia.Id)
            {
                return BadRequest();
            }

            db.Entry(browarnia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrowarniaExists(id))
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

        // POST: api/Browarnias
        [ResponseType(typeof(Browarnia))]
        public async Task<IHttpActionResult> PostBrowarnia(Browarnia browarnia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Browarnias.Add(browarnia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = browarnia.Id }, browarnia);
        }

        // DELETE: api/Browarnias/5
        [ResponseType(typeof(Browarnia))]
        public async Task<IHttpActionResult> DeleteBrowarnia(int id)
        {
            Browarnia browarnia = await db.Browarnias.FindAsync(id);
            if (browarnia == null)
            {
                return NotFound();
            }

            db.Browarnias.Remove(browarnia);
            await db.SaveChangesAsync();

            return Ok(browarnia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrowarniaExists(int id)
        {
            return db.Browarnias.Count(e => e.Id == id) > 0;
        }
    }
}