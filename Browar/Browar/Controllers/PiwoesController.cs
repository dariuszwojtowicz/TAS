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
    using Browar.Serwer;

    public class PiwoesController : ApiController
    {
        private Serwer.ServiceSoapClient klient = new ServiceSoapClient();
        private BrowarContext db = new BrowarContext();

        // GET: api/Piwoes
        public IQueryable<PiwoDTO> GetPiwoes()
        {
            var piwoes = from p in db.Piwoes
                        select new PiwoDTO()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Browarnia = p.Browarnia.Name
                        };
            return piwoes;
        }

        // GET: api/Piwoes/5
        [ResponseType(typeof(PiwoDetailDTO))]
        public async Task<IHttpActionResult> GetPiwo(int id)
        {
            var piwo = await db.Piwoes.Include(p => p.Browarnia).Select(p =>
                new PiwoDetailDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Power = p.Power,
                    Price = p.Price,
                    Browarnia = p.Browarnia.Name,
                    Genre = p.Genre
                }).SingleOrDefaultAsync(p => p.Id == id);
            if (piwo == null)
            {
                return NotFound();
            }
            var hello = klient.HelloWorld();
            piwo.Name = hello;
            return Ok(piwo);
        } 

        // PUT: api/Piwoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPiwo(int id, Piwo piwo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piwo.Id)
            {
                return BadRequest();
            }

            db.Entry(piwo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiwoExists(id))
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

        // POST: api/Piwoes
        [ResponseType(typeof(Piwo))]
        public async Task<IHttpActionResult> PostPiwo(Piwo piwo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Piwoes.Add(piwo);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            db.Entry(piwo).Reference(x => x.Browarnia).Load();

            var dto = new PiwoDTO()
            {
                Id = piwo.Id,
                Name = piwo.Name,
                Browarnia = piwo.Browarnia.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = piwo.Id }, dto);
        }

        // DELETE: api/Piwoes/5
        [ResponseType(typeof(Piwo))]
        public async Task<IHttpActionResult> DeletePiwo(int id)
        {
            Piwo piwo = await db.Piwoes.FindAsync(id);
            if (piwo == null)
            {
                return NotFound();
            }

            db.Piwoes.Remove(piwo);
            await db.SaveChangesAsync();

            return Ok(piwo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PiwoExists(int id)
        {
            return db.Piwoes.Count(e => e.Id == id) > 0;
        }
    }
}