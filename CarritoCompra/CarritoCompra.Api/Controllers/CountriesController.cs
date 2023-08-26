using CarritoCompra.Api.Data;
using CarritoCompra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace CarritoCompra.Api.Controllers
{

    [ApiController]
    [Route("/api/countries")]
    public class CountriesController:ControllerBase
    {
        private readonly DataContext _context;

        //creamos  un contructor  ctor y le inyectamos datacontext
       
        public CountriesController(DataContext context)
        {
            _context = context;
        }


        //metodos GET TRAER INFORMACION
      

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }
        //metodo para editar
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if(country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        //metodos POST

        [HttpPost]

        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        //metodos PUT  MODIFICAR

        [HttpPut]

        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        //metodo para Eliminar
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
