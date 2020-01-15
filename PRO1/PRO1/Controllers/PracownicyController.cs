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
public class PracownicyController : ControllerBase
{
    private s17090Context _context;

    public PracownicyController(s17090Context context)
    {
        _context = context;
    }

    //pizzas
    [HttpGet]
    public IActionResult GetPracownicy()
    {
        return Ok(_context.Pracownik.ToList());
    }
    //pizzas/id(numer)
    [HttpGet("{id:int}")]
    public IActionResult GetPracownik(int id)
    {
        var pracownik = _context.Pracownik.FirstOrDefault(e => e.IdPracownika == id);
        if (pracownik == null)
        {
            return NotFound(); //404
        }

        return Ok(pracownik);
    }

}
}