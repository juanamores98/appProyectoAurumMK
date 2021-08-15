using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace web.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            IEnumerable<InventarioProducto> lista= null;
            try
            {
                IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                lista = _ServiceInventarioProducto.GetInventarioProducto();
                ViewBag.registroEntradas = _ServiceRegistroMovimiento.GetRegistroMovimiento().Where(r => r.IdTipoMovimiento == 1).Count();
                ViewBag.registroSalidas = _ServiceRegistroMovimiento.GetRegistroMovimiento().Where(m => m.IdTipoMovimiento == 2).Count();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: CalificacionUsuario
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult CalificacionesIndex()
        {
            IServiceCalificacionUsuario _service = new ServiceCalificacionUsuario();
            return View(_service.GetCalificacionUsuarioByEstadoSistemaID(1));
        }
        // GET: Reports/ReporteMovimientosIndex/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult ReporteMovimientosIndex()
        {
            IEnumerable<RegistroMovimiento> lista = null;
            try
            {
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                lista = _ServiceRegistroMovimiento.GetRegistroMovimiento();
  
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: Reports/ReporteMovimientoDetails/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult ReporteMovimientoDetails(int? id)
        {
            IEnumerable<RegistroMovimiento> lista = null;
            try
            {
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                RegistroMovimiento oRegistroMovimiento = _ServiceRegistroMovimiento.GetRegistroMovimientoByID(id.Value);
                return View(oRegistroMovimiento);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult ReporteVentas()
        {
            IEnumerable<PedidoProducto> lista = null;
            List<PedidoProducto> listaDiferentes = new List<PedidoProducto>();
            ViewBag.Vendido1 = null;
            ViewBag.Vendido1 = null;
            ViewBag.Vendido1 = null;

            ViewBag.cantidad1 = null;
            try
            {
                //Primero creo la instancia del service
                IServicePedidoProducto _ServicePedidoProducto = new ServicePedidoProducto();
                IServiceProducto _ServiceProducto = new ServiceProducto();
                //llamo el metodo que trae los PedidoProductos y guardo la lista
                lista = _ServicePedidoProducto.GetPedidoProducto();

                //Logica para sacar los datos que sean diferentes
                //primero estoy metiendo en una lista todo lo que encuentre diferente (los id producto)
                if (lista.Count() > 0)
                {
                    listaDiferentes.Add(lista.ElementAt(0));
                    listaDiferentes.ElementAt(0).Cantidad = 0;
                
                for (int i = 0; i < lista.Count(); i++)
                {
                    if (listaDiferentes.Contains(lista.ElementAt(i)))
                    {
                    }
                    else
                    {
                        listaDiferentes.Add(lista.ElementAt(i));
                        listaDiferentes.ElementAt(i).Cantidad = 0;
                    }
                }
                //luego de sacar lo diferente, tengo que contar la cantidad de veces que aparecen en la lista
                for (int i = 0; i < listaDiferentes.Count(); i++)
                {
                    for (int j = 0; j < lista.Count(); j++)
                    {
                        if (listaDiferentes.ElementAt(i).IdProducto == lista.ElementAt(j).IdProducto)
                        {
                            listaDiferentes.ElementAt(i).CantidadVentas += 1;
                        }
                    }
                }
                //Aca se saca la cantidad de producto vendido
                for (int i = 0; i < listaDiferentes.Count(); i++)
                {
                    for (int j = 0; j < lista.Count(); j++)
                    {
                        if (listaDiferentes.ElementAt(i).IdProducto == lista.ElementAt(j).IdProducto)
                        {
                            listaDiferentes.ElementAt(i).Cantidad += lista.ElementAt(j).Cantidad;
                        }
                    }
                }
                //Luego de esto debo sacar los tres mayores
                listaDiferentes.OrderByDescending(PedidoProducto => PedidoProducto.CantidadVentas).ToList();
                //Crear los viewbags, recordar que son 6, tres para el objeto y 3 para las cantidades vendidas
                ViewBag.Vendido1 = _ServiceProducto.GetProductoByID(listaDiferentes.ElementAt(0).IdProducto);
                ViewBag.Vendido2 = _ServiceProducto.GetProductoByID(listaDiferentes.ElementAt(1).IdProducto);
                ViewBag.Vendido3 = _ServiceProducto.GetProductoByID(listaDiferentes.ElementAt(2).IdProducto);
                //cantidad vendida
                ViewBag.cantidad1 = listaDiferentes.ElementAt(0).Cantidad;
                ViewBag.cantidad2 = listaDiferentes.ElementAt(1).Cantidad;
                ViewBag.cantidad3 = listaDiferentes.ElementAt(2).Cantidad;
            }
                //retornar la lista para hacer el count
                
                return View(lista);
            }

            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
    }
}