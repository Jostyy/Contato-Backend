using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contato.DataAccess.Model
{
    public class Telefone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long telefoneid { get; set; }
        [Required(ErrorMessage = "telefone é obrigatorio")]
        public string telefone { get; set; }

        public long contatoid { get; set; }
        [ForeignKey("contatoid")]
        public Contato contato { get; set; }
    }
}