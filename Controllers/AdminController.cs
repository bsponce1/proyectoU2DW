using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoDesarrWebU2.Models;
using ProyectoDesarrWebU2.Models.db;
using ProyectoDesarrWebU2.Models.ViewModels;


namespace ProyectoDesarrWebU2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult HomeAdmin()
        {
            return View();
        }

        public ActionResult Peliculas()
        {
            List<ListPeliculaViewModel> listaPeliculas;
            using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
            {
                listaPeliculas = (from p in db.pelicula
                                 select new ListPeliculaViewModel
                                 {
                                     idpel = p.idpel,
                                     titulopel = p.titulopel,
                                     preciopel = p.preciopel,
                                 }).ToList();
            }
            return View(listaPeliculas);
        }

        //Funcion Eliminar Usuario
        public ActionResult EliminarPeli(int id)
        {
            using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
            {
                var oPeliculas = db.pelicula.Find(id);
                db.pelicula.Remove(oPeliculas);
                db.SaveChanges();
            }
            return Redirect("~/Admin");
        }

        public ActionResult Usuarios()
        {
            List<ListaUsuariosViewModel> listaUsuarios;
            using(Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
            {
                listaUsuarios = (from u in db.usuario
                                 select new ListaUsuariosViewModel
                                 {
                                     idusuario = u.idusuario,
                                     nombreusuario = u.nombreusuario,
                                     apellidousuario = u.apellidousuario,
                                     generousuario = u.generousuario,
                                     cedulausuario = u.cedulausuario,
                                     telefonousuario = u.telefonousuario,
                                     direccionusuario = u.direccionusuario,
                                     correousuario = u.correousuario
                                 }).ToList();
            }
            return View(listaUsuarios);
        }

        //Funcion Eliminar Usuario
        public ActionResult EliminarUsu (int id)
        {
            using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
            {
                var oUsuarios = db.usuario.Find(id);
                db.usuario.Remove(oUsuarios);
                db.SaveChanges();
            }
            return Redirect("~/Admin");
        }
    }
}