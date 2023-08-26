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


        //metodos GET 
      

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }



        //metodos POST

        [HttpPost]

        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}
