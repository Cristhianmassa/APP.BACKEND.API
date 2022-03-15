using APP.Autores.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.AutoresEF.Datos.AutoresMicroServicio
{
    public class AutoresDatos
    {
        private readonly ApplicationDbContext context;

        public AutoresDatos(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AgregarAutor (Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            return await context.Autores.ToListAsync();
        }
    }
}
