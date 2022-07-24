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
    public class PeliculaController : Controller
    {
        // GET: Pelicula
        public ActionResult Index()
        {
            //Lista de tipo view model
            List<ListPeliculaViewModel> listaPeliculas;
            //conexion a la base de datos
            using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
            {//Se almacena toda la consulta que se hace con linq 
             //Este ojbeto representa a la base de datos
                listaPeliculas = (from p in db.pelicula
                                     //en el view model almacena los datos que 
                                     //esta en la base de datos
                                 select new ListPeliculaViewModel
                                 {
                                     titulopel = p.titulopel,
                                     preciopel = p.preciopel,
                                     imgpel = p.imgpel
                                     
                                 }).ToList();


            }
            //Se retorna la lista de clientes
            return View(listaPeliculas);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PeliculaViewModel peliculaModel)
        {
            try
            {

                string fileName = Path.GetFileNameWithoutExtension(peliculaModel.imgFile.FileName);
                string extension = Path.GetExtension(peliculaModel.imgFile.FileName);
                fileName = fileName + extension;

                peliculaModel.imgpel = "../imgPeliculas/catalogo/" + fileName;
                fileName = Path.Combine(Server.MapPath("../imgPeliculas/catalogo/"), fileName);
                peliculaModel.imgFile.SaveAs(fileName);

                //validar el modelo 
                if (ModelState.IsValid)
                {
                    //Conexión a la base de datos
                    using (Grupo6_playBBEMEntities db = new Grupo6_playBBEMEntities())
                    {
                        var oPelicula = new pelicula();

                        oPelicula.titulopel = peliculaModel.titulopel;
                        oPelicula.preciopel = peliculaModel.preciopel;
                        oPelicula.imgpel = peliculaModel.imgpel;
                     //   oPelicula.img_cli = clienteModel.img_cli;

                        //
                        db.pelicula.Add(oPelicula);
                        db.SaveChanges();
                    }
                    return Redirect("~/Pelicula");
                }
                return View(peliculaModel);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}