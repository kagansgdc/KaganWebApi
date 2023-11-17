using KaganWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaganWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeeklyController
    {
        static List<Weekly> Weeklylist = new List<Weekly>();
        [HttpGet]
        public List<Weekly> Get()
        {
            return Weeklylist;
        }
        [HttpGet("{id}")]
        public Weekly Get(int id)
        {
            return Weeklylist.FirstOrDefault(o => o.id == id);
        }

        [HttpPost]
        public void Post(Weekly x)
        {
            Weeklylist.Add(x);
        }
    }
}
