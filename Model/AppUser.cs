using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Login{
    public class Appuser:IdentityUser
    {
        [Column(TypeName ="nvarchar")]
        [StringLength(400)]
        public string? HomeAdress{get;set;}
    }
}