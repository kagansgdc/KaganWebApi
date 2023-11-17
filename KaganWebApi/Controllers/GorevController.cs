using KaganWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace KaganWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GorevController
    {
        static List<Daily> dailylist = new List<Daily>();
        [HttpGet]
        public List<Daily> Get( ) {
            return dailylist;
        }
        [HttpGet("{id}")]
        public Daily Get(int id)
        {
            return dailylist.FirstOrDefault(o => o.id==id);
        }

        [HttpPost]
        public void Post(Daily x) {
            dailylist.Add(x);
        }
    }
}
