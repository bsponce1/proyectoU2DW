using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDesarrWebU2.Models.ViewModels;
using ProyectoDesarrWebU2.Models.db;

namespace ProyectoDesarrWebU2.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access

        // GET: Pelicula
        public ActionResult Login()
        {
            //Lista de tipo view model
            List<ListUsuarioViewModel> listaUsuario;
            //conexion a la base de datos
            using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
            {//Se almacena toda la consulta que se hace con linq 
             //Este ojbeto representa a la base de datos
                listaUsuario = (from p in db.usuario
                                      //en el view model almacena los datos que 
                                      //esta en la base de datos
                                  select new ListUsuarioViewModel
                                  {
                                      nombreusuario= p.nombreusuario,
                                      claveusuario = p.claveusuario

                                  }).ToList();
            }
            //Se retorna la lista de clientes
            return View(listaUsuario);
        }


    }
}