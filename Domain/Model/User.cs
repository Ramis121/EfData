using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Имя пользователя")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Возраст пользователя")]
        [Display(Name = "Age")]
        public int age { get; set; }
    }
}
