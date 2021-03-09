using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Contato.DataAccess.Model
{
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long contatoid { get; set; }

        [Required(ErrorMessage = "nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "email é obrigatório")]
        public string email { get; set; }
        public List<Telefone> telefone { get; set; }
    }
}