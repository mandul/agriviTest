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
        /// <summary>
        /// Ispis svih spojeva
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Ispis svih spojeva
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Ispis svih spojeva prema tipu
        /// </summary>
        /// <param name="tip"></param>
        /// <returns></returns>
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
