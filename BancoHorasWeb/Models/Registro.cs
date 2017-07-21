using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BancoHorasWeb.Models
{
    public class Registro
    {
        [Key]
        public int RegistroId { get; set; }

        [Display(Name = "Funcionario")]
        public int FuncionarioId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo {0} de preenchimento obrigatório!")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRegistro { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage ="Campo {0} de preenchimento obrigatório!")]
        [DisplayFormat(DataFormatString ="{0:hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan InicioReg { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Campo {0} de preenchimento obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan FimReg { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan TotalReg { get; set; }

        public int SaldoDias { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan SaldoHoras { get; set; }

        [Display(Name ="Gerente")]
        public int GerenteId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public virtual Gerente Gerente { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}