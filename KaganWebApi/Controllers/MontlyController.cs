using KaganWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaganWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MontlyController
    {
        static List<Montly> montlist = new List<Montly>();
        [HttpGet]
        public List<Montly> Get()
        {
            return montlist;
        }
        [HttpGet("{id}")]
        public Montly Get(int id)
        {
            return montlist.FirstOrDefault(o => o.id == id);
        }

        [HttpPost]
        public void Post(Montly x)
        {
            montlist.Add(x);
        }
    }
}
