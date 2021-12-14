using CatalogoWeb.Models;
using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoWeb.Controllers
{
    public class HomeController : Controller
    {
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeModel homeModel)
        {

            DynamicParameters param = new DynamicParameters();
            //param.Add("@Id", homeModel.Id);
            
            param.Add("@Usuario", homeModel.Usuario);
            param.Add("@Contrasena", homeModel.Contrasena);
            //DapperORM.ExecuteReturnScalar<bool>("CredencialesFind", param);

            if (DapperORM.ExecuteReturnScalar<bool>("CredencialesFind", param))
                return RedirectToAction("Index", "Producto");
            else
                return View();
           
        }
        [HttpGet]
        public ActionResult UsuarioAddorEdit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UsuarioAddorEdit(HomeModel homeModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", homeModel.Id);
            param.Add("@Usuario", homeModel.Usuario);
            param.Add("@Contrasena", homeModel.Contrasena);
            DapperORM.ExecuteWithoutReturn("UsuarioAddorEdit", param);
            return RedirectToAction("Index");
        }
    }
}
