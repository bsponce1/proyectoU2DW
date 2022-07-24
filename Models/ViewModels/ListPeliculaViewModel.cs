using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDesarrWebU2.Models.ViewModels
{
    public class ListPeliculaViewModel
    {
        public int idpel { get; set; }
        public string titulopel { get; set; }
        public Nullable<decimal> preciopel { get; set; }
        public string imgpel { get; set; }



    }
}