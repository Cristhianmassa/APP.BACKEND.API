using APP.Autores.Entidades;
using APP.Autores.Negocio.Interfaces;
using APP.AutoresEF.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APP.MICROSERVICIO.API.Areas.AutoresMicroServicio.Controllers
{
    [ApiController] 
    [Route("api/autoresmicroservicio/autores")] //Otros: [Route("api/autoresmicroservicio/[controller]")]
    public class AutoresController : ControllerBase
    {       
        private readonly IAutoresMicroServicio autoresNegocio;             

        public AutoresController(IAutoresMicroServicio autoresNegocio)
        {           
            this.autoresNegocio = autoresNegocio;           
        }

        [HttpGet]
        [HttpGet("listado")] //Otra ruta -->/api/autoresmicroservicio/autores/listado
        [HttpGet("/listado")] //Otra ruta --> /listado
        public async Task<List<Autor>> Get()
        //public List<Autor> Get() //Programacion sincrona
        {
            return await autoresNegocio.ObtenerConLibros();
           
        }


        [HttpGet("ListarTodos")]
        public async Task<ActionResult<List<Autor>>> ListarTodos()
        {
            return await autoresNegocio.ObtenerTodos();
        }

        [HttpGet("PrimerAutor")]
        //public async Task<ActionResult<Autor>> PrimerAutor()
        public async Task<ActionResult<Autor>> PrimerAutor([FromHeader] int miValor, [FromQuery] string nombre)
        {
            return await autoresNegocio.PrimerAutor();

        }
              

        [HttpGet("primero2")] //Aqui no es necesario asincrona porque no comunico con BD, ni con apis de terceros, operac I/O
        public ActionResult<Autor> PrimerAutor2()
        {

            return new Autor() { Nombre = "Inventado" }; //Viene de memoria entonces el async sobra
        }

        //parametros de ruta
        [HttpGet("{id:int}")] //restringida por un tipo de dato
        public async Task<ActionResult<Autor>> Get(int id)        {
            var autor = await autoresNegocio.Get(id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        //varios parametros  [HttpGet("{id:int}/{param2}")] 
        //valor opcional el segundo valor [HttpGet("{id:int}/{param2?}")] 
        //valor por defecto el segundo valor  [HttpGet("{id:int}/{param2=persona}")]   
        [HttpGet("{id:int}/{param2}")]

         public async Task<ActionResult<Autor>> Get(int id, string param2) //ASINCRONA
        //public ActionResult<Autor> Get(int id, string param2) //SINCRONA ES MEJOR SE LO QUE VOY A RETORNAR
        //public IActionResult Get(int id, string param2) //SINCRONA //MAS CUIDADO A TENER EN CUENTA
        {
            var autor = await autoresNegocio.Get(id);           
            if (autor == null)
            {
                return NotFound();
            }
            return autor; //para IActionResult
        }

        [HttpGet("{nombre}")] //Ruta sin restriccion
        public async Task<ActionResult<Autor>> Get([FromRoute] string nombre)
        {
            var autor = await autoresNegocio.Get(nombre);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        //ModelBinders
        //[FromServices] Desde servicios 
        //[FromForm] para archivos word, imagenes, pdf, etc. desde nuestros clientes.
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            //Validacion a nivel del controller util al examinar bd es mas sencillo desde aqui
            bool existeAutorConElMismoNombre = await autoresNegocio.ExisteAutorMismoNombre(autor.Nombre);
            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {autor.Nombre}. "); 
            }

            var result = await autoresNegocio.Post(autor);            
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la url");
            }

            var existe = await autoresNegocio.ExisteAutor(id);
            if (!existe)
            {
                return NotFound(); //404
            }

            var result = await autoresNegocio.Put(autor, id);
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await autoresNegocio.ExisteAutor(id);
            if (!existe)
            {
                return NotFound(); //404
            }

            var result = await autoresNegocio.Delete(id);
            return Ok();
        }               

       
    }
}
