using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BancoHorasWeb.Models
{
    public class Gerente
    {
        [Key]
        public int GerenteId { get; set; }

        [Display(Name ="CPF Funcionário")]
        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}