using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoDesarrWebU2.Models.ViewModels
{
    public class PeliculaViewModel
    {
        public int idpel { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Título")]
        public string titulopel { get; set; }

        [Required]
        [Display(Name = "Precio")]
        
        public Nullable<decimal> preciopel { get; set; }

        [Display(Name = "Subir imagen")]
        public string imgpel { get; set; }

        [NotMapped]
        public HttpPostedFileBase imgFile { get; set; }

    }


}