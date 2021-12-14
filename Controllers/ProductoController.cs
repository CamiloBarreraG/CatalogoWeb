using CatalogoWeb.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoWeb.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<ProductoModel>("ProductoViewAll", null));
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                return View(DapperORM.ReturnList<ProductoModel>("productoViewById", param).FirstOrDefault<ProductoModel>());
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(ProductoModel productoModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", productoModel.Id);
            param.Add("@Codigo", productoModel.Codigo);
            param.Add("@Categoria", productoModel.Categoria);
            param.Add("@Nombre", productoModel.Nombre);
            param.Add("@Cantidad", productoModel.Cantidad);
            param.Add("@Precio", productoModel.Precio);
            param.Add("@Fecha", productoModel.Fecha);
            param.Add("@Imagen", productoModel.Imagen);
            param.Add("@Descripcion", productoModel.Descripcion);
            DapperORM.ExecuteWithoutReturn("ProductoAddOrEdit", param); 
            return RedirectToAction("Index");
        }

        public ActionResult FilterCategoria(string Categoria = "")
        {
            if (Categoria != "")
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Categoria", Categoria);
                return View(DapperORM.ReturnList<ProductoModel>("ProductoViewCategoria", param));
            }
            else
            {
                return View();
            }
        }
    }
}
