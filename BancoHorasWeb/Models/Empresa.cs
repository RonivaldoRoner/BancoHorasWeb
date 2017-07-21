using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BancoHorasWeb.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]    
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Pais { get; set; }

        [Display(Name ="CPF Responsável")]
        public int ResponsavelId { get; set; }

        public virtual Responsavel Responsavel { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }

        
    }
}