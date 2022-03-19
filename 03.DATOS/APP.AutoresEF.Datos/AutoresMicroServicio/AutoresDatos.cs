using APP.Autores.Entidades;
using APP.AutoresEF.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.AutoresEF.Datos.AutoresMicroServicio
{
   

    public class AutoresDatos : IAutoresMicroServicioDatos
    {
        private readonly ApplicationDbContext context;

        public AutoresDatos(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<List<Autor>> ObtenerConLibros()
        {
            //return await context.Autores.Include(x => x.Libros).ToListAsync();
            //return context.Autores.Include(x => x.Libros).ToList(); //SICRONO
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }
             

        public async Task<List<Autor>> ObtenerTodos()
        {
            return await context.Autores.ToListAsync();
        }

        public async Task<Autor> PrimerAutor()
        {
            return await context.Autores.FirstOrDefaultAsync();
           
        }

        public async Task<Autor> Get(int id)
        {
            return await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Autor> Get(string nombre)
        {
            return await context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
        }

        public async Task<bool> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Put(Autor autor, int id)
        {
            context.Update(autor);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteAutor(int id)
        {
           return await context.Autores.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteAutorMismoNombre(string nombre)
        {
            return await context.Autores.AnyAsync(x=>x.Nombre == nombre);
        }
    }
}
