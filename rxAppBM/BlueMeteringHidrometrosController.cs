using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace rxAppBM
{
    [RoutePrefix("api/BlueMeteringHidrometros")]
    public class BlueMeteringHidrometrosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BlueMeteringHidrometros
        [HttpGet]
        [Route("")]
        public IQueryable<BlueMeteringHidrometro> GetBlueMeteringHidrometros()
        {
            return db.BlueMeteringHidrometros;
        }

        // GET: api/BlueMeteringHidrometros/5
        //[ResponseType(typeof(BlueMeteringHidrometro))]
        //public IHttpActionResult GetBlueMeteringHidrometro(Guid id)
        //{
        //    BlueMeteringHidrometro blueMeteringHidrometro = db.BlueMeteringHidrometros.Find(id);
        //    if (blueMeteringHidrometro == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(blueMeteringHidrometro);
        //}

        // GET: api/BlueMeteringHidrometros/{RedeIotId}
        [HttpGet]
        [Route("{redeIotId}")]
        [ResponseType(typeof(BlueMeteringHidrometro))]
        public IHttpActionResult GetBlueMeteringHidrometro(string redeIotId)
        {
            BlueMeteringHidrometro blueMeteringHidrometro = db.BlueMeteringHidrometros.FirstOrDefault(h => h.RedeIotId == redeIotId);
            if (blueMeteringHidrometro == null)
            {
                return NotFound();
            }

            return Ok(blueMeteringHidrometro);
        }

        // PUT: api/BlueMeteringHidrometros/5
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlueMeteringHidrometro(Guid id, BlueMeteringHidrometro blueMeteringHidrometro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blueMeteringHidrometro.BlueMeteringHidrometroId)
            {
                return BadRequest();
            }

            db.Entry(blueMeteringHidrometro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlueMeteringHidrometroExists(id))
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

        // POST: api/BlueMeteringHidrometros
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BlueMeteringHidrometro))]
        public IHttpActionResult PostBlueMeteringHidrometro(BlueMeteringHidrometro blueMeteringHidrometro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BlueMeteringHidrometros.Add(blueMeteringHidrometro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BlueMeteringHidrometroExists(blueMeteringHidrometro.BlueMeteringHidrometroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = blueMeteringHidrometro.BlueMeteringHidrometroId }, blueMeteringHidrometro);
        }

        // DELETE: api/BlueMeteringHidrometros/5
        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(BlueMeteringHidrometro))]
        public IHttpActionResult DeleteBlueMeteringHidrometro(Guid id)
        {
            BlueMeteringHidrometro blueMeteringHidrometro = db.BlueMeteringHidrometros.Find(id);
            if (blueMeteringHidrometro == null)
            {
                return NotFound();
            }

            db.BlueMeteringHidrometros.Remove(blueMeteringHidrometro);
            db.SaveChanges();

            return Ok(blueMeteringHidrometro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlueMeteringHidrometroExists(Guid id)
        {
            return db.BlueMeteringHidrometros.Count(e => e.BlueMeteringHidrometroId == id) > 0;
        }
    }
}