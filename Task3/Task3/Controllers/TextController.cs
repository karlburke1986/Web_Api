using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task3.Models;

namespace Task3.Controllers
{
    public class TextController : ApiController
    {
        TextContext db = new TextContext();
        
        
        // GET: api/Text

        public  IHttpActionResult GetAll()
        {
            List<Text> temp = db.Texts.OrderBy(t => t.ID).ToList();

            if(temp.Count() > 0)
            {
                return Ok(temp);
            }
            else
            {
                return NotFound();
            }
            
        }

        public IHttpActionResult PutUpdateEntry(int id, Text text)
        {
            if(id > 0 && ModelState.IsValid)
            {
                var temp = db.Texts.Find(id);

                if(temp.ID != 0)
                {
                    db.Entry(text).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Ok(text);
                }
                else
                {
                    return BadRequest("Entry not found");
                }
            }

            else
            {
                return NotFound();
            }
        }
        

        // POST: api/Text
        public IHttpActionResult PostNewMessage(Text text)
        {
            if(ModelState.IsValid)
            {
                db.Texts.Add(text);

                return Created("DefaultApi", text);
            }
            else
            {
                return NotFound();
            }

        }

        // DELETE: api/Text/5
        public IHttpActionResult DeleteMessage(int number)
        {
            Text texts = (from item in db.Texts
                          where item.NumberReceiver.Equals(number)
                          select item).FirstOrDefault();

            if (texts.ID != 0)
            {
                db.Texts.Remove(texts);
                db.SaveChanges();

                return Ok(texts);
            }
            else
            {
                return NotFound();
            }       
        }
    }
}
