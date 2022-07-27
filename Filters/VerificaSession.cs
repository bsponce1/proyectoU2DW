using ProyectoDesarrWebU2.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDesarrWebU2.Controllers;

namespace ProyectoDesarrWebU2.Filters
{
    public class VerificaSession: ActionFilterAttribute
    {
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (usuario)HttpContext.Current.Session["User"];
                if(oUsuario == null)
                {

                    if(filterContext.Controller is AccessController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Access/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Access/Login");
            }
        }

    }
}