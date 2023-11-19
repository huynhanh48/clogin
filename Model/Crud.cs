using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Model
{
    public class Crud
    {
        [Key]
        public int IDCrud {get;set;}
        [StringLength(255,ErrorMessage ="Khong Vuot Qua 255")]
        public string? Title {get;set;}
    }
}