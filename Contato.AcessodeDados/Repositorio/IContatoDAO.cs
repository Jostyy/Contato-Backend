using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contato.DataAccess.Repositorio
{
    public interface IContatoDAO
    {
        List<Model.Contato> GetAllContato();
        Task<Model.Contato> CreateContato(Model.Contato contato);
        Task<Model.Contato> GetContato(long? id);
        Task<Model.Contato> UpdateContato(Model.Contato contato);
        Task DeleteContato(long? id);
    }
}
