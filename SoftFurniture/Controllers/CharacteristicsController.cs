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
using SofFurniture.Models;
using SoftFurniture.Models;

namespace SofFurniture.Controllers
{
    public class CharacteristicsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Characteristics
        public IQueryable<Characteristic> GetCharacteristics()
        {
            return db.Characteristics.AsQueryable();
        }

        // GET: api/Characteristics/5
        [ResponseType(typeof(Characteristic))]
        public IHttpActionResult GetCharacteristic(int id)
        {
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return NotFound();
            }

            return Ok(characteristic);
        }

        // PUT: api/Characteristics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharacteristic(int id, Characteristic characteristic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characteristic.Id)
            {
                return BadRequest();
            }

            db.Entry(characteristic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacteristicExists(id))
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

        // POST: api/Characteristics
        [ResponseType(typeof(Characteristic))]
        public IHttpActionResult PostCharacteristic(Characteristic characteristic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Characteristics.Add(characteristic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = characteristic.Id }, characteristic);
        }

        // DELETE: api/Characteristics/5
        [ResponseType(typeof(Characteristic))]
        public IHttpActionResult DeleteCharacteristic(int id)
        {
            Characteristic characteristic = db.Characteristics.Find(id);
            if (characteristic == null)
            {
                return NotFound();
            }

            db.Characteristics.Remove(characteristic);
            db.SaveChanges();

            return Ok(characteristic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharacteristicExists(int id)
        {
            return db.Characteristics.Count(e => e.Id == id) > 0;
        }
    }
}