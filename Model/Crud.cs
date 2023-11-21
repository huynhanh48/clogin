using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Login.Model
{
    public class Crud
    {
        [Key]
        public int IDCrud {get;set;}
        [StringLength(255,ErrorMessage ="Khong Vuot Qua 255")]
        [Required]
        [DisplayName("Noi Dung  Cua Trang")]
        public string? Title {get;set;}
        [Column(TypeName="nvarchar")]
        [StringLength(255,ErrorMessage ="Link Khong Qua 255")]
        [DisplayName("Tai Xuong")]
        public string? Link {get;set;}
        [Column(TypeName ="ntext")]
        [DisplayName("Noi Dung")]
        public string? Content{get;set;}
    }
}