using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRO1.Models;

namespace PRO1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private s17090Context _context;

        public PizzasController(s17090Context context)
        {
            _context = context;
        }

        //pizzas
        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }
        //pizzas/id(numer)
        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
            {
                return NotFound(); //404
            }

            return Ok(pizza);
        }

    }
}