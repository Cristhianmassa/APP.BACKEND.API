using APP.Autores.Entidades;
using APP.AutoresEF.Datos.AutoresMicroServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Autores.Negocio.AutoresMicroServicio
{
    public class AutoresNegocio
    {
        private readonly AutoresDatos autoresDatos;

        public AutoresNegocio(AutoresDatos autoresDatos)
        {
            this.autoresDatos = autoresDatos;
        }

       

        public async Task<bool> AgregarAutorAsync(Autor autor)
        {
            return await autoresDatos.AgregarAutor(autor);
        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            return await autoresDatos.ObtenerTodos();
        }
    }
}
