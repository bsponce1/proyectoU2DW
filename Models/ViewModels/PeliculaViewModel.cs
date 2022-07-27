using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoDesarrWebU2.Models.db;

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

        //factura
        public int idfact { get; set; }
        public Nullable<System.DateTime> fechafact { get; set; }
        public Nullable<decimal> ivafact { get; set; }
        public Nullable<decimal> subtotalfact { get; set; }
        [Required]
        [Display(Name = "Total a pagar")]
        public Nullable<decimal> totalfact { get; set; }
        public Nullable<int> idusuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallefactura> detallefactura { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tipopago> tipopago { get; set; }


        //tipo de pago
        [Required]
        [Display(Name = "Id tipo factura")]
        public int idtp { get; set; }
        [Required]
        [StringLength(16)]
        [Display(Name = "Número de tarjeta")]
        public string numtarjtp { get; set; }
        [Required]
        [Display(Name = "Factura")]
        public virtual factura factura { get; set; }

    }


}