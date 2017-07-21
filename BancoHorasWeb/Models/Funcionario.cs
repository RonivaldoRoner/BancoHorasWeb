using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BancoHorasWeb.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public DateTime Admissao { get; set; }

        public string Demissao { get; set; }

        [Display(Name ="Situação")]
        public int SituacaoId { get; set; }

        [Display(Name = "CNPJ Empresa")]
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        
        public virtual Situacao Situacao { get; set; }

        public virtual ICollection<Gerente> Gerente { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }

    }
}