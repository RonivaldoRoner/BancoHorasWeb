using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BancoHorasWeb.Models
{
    public class Situacao
    {
        [Key]
        public int SituacaoId { get; set; }

        [Required(ErrorMessage = "Campo {0} de preenchimento obrigatório.")]
        [Display(Name ="Situação")]
        public string Nome { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }


    }
}