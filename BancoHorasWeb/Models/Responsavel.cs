using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BancoHorasWeb.Models
{
    public class Responsavel
    {
        [Key]
        public int ResponsavelId { get; set; }

        [DisplayFormat(DataFormatString ="{0:###.###.###-##}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo {0} obrigatório!")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{10}$")]
        [Required(ErrorMessage ="Campo {0} obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:(###)####-####}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9){4})[-. ]?([0-9]{4})$",ErrorMessage ="Formato obriga válido: (000)0000-0000")]
        public string Telefone { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}