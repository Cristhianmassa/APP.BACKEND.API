using APP.Autores.Entidades;
using APP.AutoresEF.Datos;
using APP.AutoresEF.Datos.AutoresMicroServicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Autores.Negocio.AutoresMicroServicio
{
    public interface IAutoresMicroServicioNegocio
    {
        
        Task<List<Autor>> ObtenerTodos();
        Task<List<Autor>> ObtenerConLibros();
        Task<Autor> PrimerAutor();

        Task<Autor> Get(int id);
        Task<Autor> Get(string nombre);

        Task<bool> Post(Autor autor);
        Task<bool> Put(Autor autor, int id);
        Task<bool> ExisteAutor(int id);
        Task<bool> Delete(int id);
        Task<bool> ExisteAutorMismoNombre(string nombre);
    }

    public class AutoresNegocio : IAutoresMicroServicioNegocio
    {
        private readonly IAutoresMicroServicioDatos autoresDatos;

        public AutoresNegocio(IAutoresMicroServicioDatos autoresDatos)
        {          
            this.autoresDatos = autoresDatos;
        }             

        public async Task<List<Autor>> ObtenerConLibros()
        {
            return await autoresDatos.ObtenerConLibros();
        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            //return await Context.Autores.ToListAsync();
            return await autoresDatos.ObtenerTodos();
        }

        public async Task<Autor> PrimerAutor()
        {
            return await autoresDatos.PrimerAutor();
        }

        public async Task<Autor> Get(int id)
        {
            return await autoresDatos.Get(id);
           
        }

        public async Task<Autor> Get(string nombre)
        {
            return await autoresDatos.Get(nombre);
        }


        public async Task<bool> Post(Autor autor)
        {
            return await autoresDatos.Post(autor);
        }

        public async Task<bool> Put(Autor autor, int id)
        {
            return await autoresDatos.Put(autor, id);
        }

        public async Task<bool> ExisteAutor(int id)
        {
            return await autoresDatos.ExisteAutor(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await autoresDatos.Delete(id);
        }

        public async Task<bool> ExisteAutorMismoNombre(string nombre)
        {
            return await autoresDatos.ExisteAutorMismoNombre(nombre);
        }
    }
}
