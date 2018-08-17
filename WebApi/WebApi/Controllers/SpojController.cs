using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;


using System.IO;
using System.Web;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;


namespace WebApi.Controllers
{
    public class SpojController : ApiController
    {
        private AgriviDBEntities db = new AgriviDBEntities();


        // GET api/values
        public IEnumerable<string> Get()
        {
            string json = null;
            try
            {
                var ret = db.SpojTable.ToList();
                json = JsonConvert.SerializeObject(ret);
            }
            catch
            {
                Log.Error("Get: DB error");
            }                  
            yield return json;
        }

        // POST api/all
        [HttpPost]
        [Route("api/all")]
        public IEnumerable<string> Post()
        {
            string json = null;
            try
            {
                var ret = db.SpojTable.ToList();
                json = JsonConvert.SerializeObject(ret);
            }
            catch
            {
                Log.Error("Post/all: DB error");
            }
            
            yield return json;
        }

        // POST api/tip 
        [HttpPost]
        [Route("api/tip")]
        public IEnumerable<string> Post([FromBody]string tip)
        {
            string json = null;
            try
            {
                var ret = db.SpojTable.Where(x => x.Tip == tip);
                json = JsonConvert.SerializeObject(ret);
            }
            catch
            {
                Log.Error("Post/tip: DB error");
            }
            
            yield return json;
        }
    }
}
