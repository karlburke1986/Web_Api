using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class TextController : ApiController
    {
        // GET: Text
        public IHttpActionResult PostMessage(Text textModel)
        {
            if(ModelState.IsValid)
            {
                StreamWriter sw = new StreamWriter("E:\\Test.txt");

                string today = System.DateTime.Now.ToString();

                sw.WriteLine("Sender : " + textModel.NumberSender);
                sw.WriteLine("Receiver : " + textModel.NumberReceiver);
                sw.WriteLine("Message : " + textModel.NumberReceiver);
                sw.WriteLine("Time : " + today);

                sw.Close();

                return Created("DefaultApi", textModel);
            }

            else
            {
                return NotFound();
            }

            
        }
    }
}