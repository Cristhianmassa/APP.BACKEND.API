using APP.Autores.Entidades;
using APP.AutoresEF.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP.MICROSERVICIO.API.Areas.AutoresMicroServicio.Controllers
{
    [ApiController]
    [Route("api/autoresmicroservicio/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        //private readonly AutoresNegocio autoresNegocio;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
           // this.autoresNegocio = autoresNegocio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            //return await autoresNegocio.ObtenerTodos();
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la url");
            }

            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound(); //404
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound(); //404
            }

            context.Remove(new Autor() { Id= id });
            await context.SaveChangesAsync();
            return Ok();
        }

        

        //public AutoresController(AutoresNegocio autoresNegocio)
        //{
        //    AutoresNegocio = autoresNegocio;
        //}

        //public AutoresNegocio AutoresNegocio { get; }


        //[HttpGet]
        //public async Task<ActionResult<List<Autor>>> Get()
        // {
        //     return await AutoresNegocio.ObtenerTodos();
        // }


        // [HttpPost]
        // public async Task<ActionResult> Post(Autor autor)
        // {
        //     var result = await AutoresNegocio.AgregarAutorAsync(autor);         
        //     return Ok();        

        // }
    }
}
