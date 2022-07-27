using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDesarrWebU2.Models.ViewModels;
using ProyectoDesarrWebU2.Models.db;
using System.IO;


namespace ProyectoDesarrWebU2.Controllers
{
    public class UsuarioController : Controller


    {
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ListUsuarioViewModel usuarioModel)
        {
            try
            {

                string fileName = Path.GetFileNameWithoutExtension(usuarioModel.imgFile.FileName);
                string extension = Path.GetExtension(usuarioModel.imgFile.FileName);
                fileName = fileName + extension;

                usuarioModel.imagenusuario = "../imgPeliculas/catalogo/" + fileName;
                fileName = Path.Combine(Server.MapPath("../imgPeliculas/catalogo/"), fileName);
                usuarioModel.imgFile.SaveAs(fileName);


                //validar el modelo 
                if (ModelState.IsValid)
                {
                    //Conexión a la base de datos
                    using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
                    {
                        var oUsuario = new usuario();

                        oUsuario.nombreusuario = usuarioModel.nombreusuario;
                        oUsuario.apellidousuario = usuarioModel.apellidousuario;
                        oUsuario.generousuario = usuarioModel.generousuario;
                        oUsuario.cedulausuario = usuarioModel.cedulausuario;
                        oUsuario.telefonousuario = usuarioModel.telefonousuario;
                        oUsuario.direccionusuario = usuarioModel.direccionusuario;
                        oUsuario.correousuario = usuarioModel.correousuario;
                        oUsuario.claveusuario = usuarioModel.claveusuario;
                        oUsuario.imagenusuario = usuarioModel.imagenusuario;

                        db.usuario.Add(oUsuario);
                        db.SaveChanges();
                    }
                    return Redirect("~/Pelicula");
                }
                return View(usuarioModel);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}