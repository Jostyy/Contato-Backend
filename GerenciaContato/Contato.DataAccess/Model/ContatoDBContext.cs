using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Contato;


namespace Contato.DataAccess.Model
{
   
            public class ContatoDBContext : DbContext
            {
                public ContatoDBContext(DbContextOptions<ContatoDBContext> options) : base(options)
                {
                }
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Telefone>()
                        .HasOne<Contato>(t => t.contato)
                        .WithMany(c => c.telefone)
                        .HasForeignKey(c => c.contatoid);
                }
                public DbSet<Contato> contato { get; set; }
                public DbSet<Telefone> telefone { get; set; }
    }
}


