using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDesarrWebU2.Models.ViewModels
{
    public class ListUsuarioViewModel
    {
        public int idusuario { get; set; }
        [Required]
        [StringLength(80)]
        [Display(Name = "Nombre")]
        public string nombreusuario { get; set; }
        [Required]
        [StringLength(80)]
        [Display(Name = "Apellido")]
        public string apellidousuario { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Genero")]
        public string generousuario { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Cedula")]
        public string cedulausuario { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Telefono")]
        public string telefonousuario { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Direccion")]
        public string direccionusuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Correo")]
        public string correousuario { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Clave")]
        public string claveusuario { get; set; }

        [Display(Name = "Subir imagen")]
        public string imagenusuario { get; set; }

        [NotMapped]
        public HttpPostedFileBase imgFile { get; set; }
    }
}