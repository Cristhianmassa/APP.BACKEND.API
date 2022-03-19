using APP.Autores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Autores.Negocio.Interfaces
{
    public interface IAutoresMicroServicio
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
}
