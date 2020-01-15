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
public class SkladnikiController : ControllerBase
{
    private s17090Context _context;

    public SkladnikiController(s17090Context context)
    {
        _context = context;
    }

    //pizzas
    [HttpGet]
    public IActionResult GetSkladniki()
    {
        return Ok(_context.Skladnik.ToList());
    }
    //pizzas/id(numer)
    [HttpGet("{id:int}")]
    public IActionResult GetSkladnik(int id)
    {
        var skladnik = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == id);
        if (skladnik == null)
        {
            return NotFound(); //404
        }

        return Ok(skladnik);
    }

}
}