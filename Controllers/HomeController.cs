using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace candy_proj.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            return View("Index");
        }
    }
}
