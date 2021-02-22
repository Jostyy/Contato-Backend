using Contato.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contato.DataAccess.Repositorio
{
    public class ContatoDAO : IContatoDAO
    {
        private readonly ContatoDBContext dbContext;

        public ContatoDAO(ContatoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Model.Contato> CreateContato(Model.Contato contato)
        {
            await dbContext.contato.AddAsync(contato);
            dbContext.SaveChanges();
            return contato;
        }

        public async Task<Model.Contato> GetContato(long? contatoid)
        {
            Model.Contato contato = await dbContext.contato.Include(c => c.telefone).
                FirstOrDefaultAsync(c => c.contatoid == contatoid.Value);
            ;
            return contato;
        }

        public List<Model.Contato> GetAllContato()
        {
            return dbContext.contato.Include(contato => contato.telefone).ToList();
        }

        public async Task<Model.Contato> UpdateContato(Model.Contato contato)
        {
            var checkContato = await GetContato(contato.contatoid);
            if (checkContato == null) return null;

            var local = dbContext.Set<Model.Contato>().Local
                .FirstOrDefault(entry => entry.contatoid.Equals(contato.contatoid));
            
            if(local != null)
                dbContext.Entry(local).State = EntityState.Detached;
            
            dbContext.Entry(contato).State = EntityState.Modified;
            dbContext.contato.Update(contato);
            await dbContext.SaveChangesAsync();

            return contato;
        }
        
        public async Task DeleteContato(long? id)
        {
            var c = await GetContato(id);

            dbContext.Entry(c).State = EntityState.Deleted;
            dbContext.contato.Remove(c);
            await dbContext.SaveChangesAsync();
      
        }
    }
}
