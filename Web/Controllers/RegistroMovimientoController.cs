using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;

namespace Web.Controllers
{
    public class RegistroMovimientoController : Controller
    {
        // GET: RegistroMovimiento
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Index()
        {
            IEnumerable<Inventario> lista = null;
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                lista = _ServiceInventario.GetInventarioByEstadoSistemaID(1);
                ViewBag.title = "Lista Inventarios";
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
        // GET: RegistroMovimiento/InventoryEntry/5
        [CustomAuthorize((int)Roles.Administrador)]
        public ActionResult InventoryEntry(int? id)
        {
            try
            {
                IServiceInventario _ServiceInventario = new ServiceInventario();
                IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();
                IServiceProducto _ServiceProducto = new ServiceProducto();
                ViewBag.listaSeleccionUsuarios = listaSeleccionUsuarios();
                ViewBag.listaSeleccionMotivo = listaSeleccionMotivo();
                ViewBag.listaProductos = _ServiceProducto.GetProductoNonIncludeInventarioID(id.Value);
                ViewBag.inventarioProducto = _ServiceInventarioProducto.GetInventarioProductoByInventarioID(id.Value);
                Inventario inventario = _ServiceInventario.GetInventarioByID(id.Value);
                return View(inventario);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Registro Movimiento";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        //POST: RegistroMovimiento/InventoryEntryConfirm/5
        [CustomAuthorize((int)Roles.Administrador)]
        [HttpPost]
        public ActionResult InventoryEntryConfirm(string idInventario, string idUsuario, string fechaHora, string comentario, string idMotivoMovimiento, string[] idProducto, string[] stockMinimo,string[] stock, string[] estante)
        {
            try
            {
                //Servicios
                IServiceRegistroMovimiento _ServiceRegistroMovimiento = new ServiceRegistroMovimiento();
                IServiceRegistroProducto _ServiceRegistroProducto = new ServiceRegistroProducto();
                IServiceInventarioProducto _ServiceInventarioProducto = new ServiceInventarioProducto();

                //Crer y guardar Registro Movimiento
                RegistroMovimiento oRegistroMovimiento = new RegistroMovimiento();
                oRegistroMovimiento.IdUsuario= int.Parse(idUsuario);
                oRegistroMovimiento.FechaHora = fechaHora;
                oRegistroMovimiento.Comentario = comentario;
                oRegistroMovimiento.IdTipoMovimiento = 1;//Entrada
                oRegistroMovimiento.IdMotivoMovimiento= int.Parse(idMotivoMovimiento);
                oRegistroMovimiento.IdInventario = int.Parse(idInventario);
                _ServiceRegistroMovimiento.Save(oRegistroMovimiento);

                //Creacion lista elementos a añaidr al inventario y lista de elementos del registro  
                //List<InventarioProducto> listaInventarioProducto = new List<InventarioProducto>();
                //List<RegistroProducto> listaRegistroProducto = new List<RegistroProducto>();
                for (int i=0;i< idProducto.Length;i++)
                {
                    //Creacion y guardado de producto del inventario
                    InventarioProducto oInventarioProducto = new InventarioProducto();
                    oInventarioProducto.IdProducto = int.Parse(idProducto[i]);
                    oInventarioProducto.IdInventario = int.Parse(idInventario);
                    oInventarioProducto.StockMinimo = int.Parse(stockMinimo[i]);
                    oInventarioProducto.Stock = int.Parse(stock[i]);
                    oInventarioProducto.Estante = estante[i];
                    _ServiceInventarioProducto.Save(oInventarioProducto,1);//Guarado con estado sistema activo
                    
                    //Creacion y guardado de registro del registro movimiento
                    RegistroProducto oRegistroProducto = new RegistroProducto();
                    oRegistroProducto.IdProducto = int.Parse(idProducto[i]);
                    oRegistroProducto.IdMovimiento = _ServiceRegistroMovimiento.GetRegistroMovimiento().LastOrDefault().IdMovimiento;
                    oRegistroProducto.Cantidad= int.Parse(stock[i]);
                    _ServiceRegistroProducto.Save(oRegistroProducto);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Registro Movimiento";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        

        //METODOS AUXILIARES
        private SelectList listaSeleccionMotivo()
        {
            //Lista de motivos de registro
            IServiceMotivoMovimiento _ServiceMotivoMovimiento = new ServiceMotivoMovimiento();
            IEnumerable<MotivoMovimiento> listaMotivoMovimiento = _ServiceMotivoMovimiento.GetMotivoMovimiento();
            return new SelectList(listaMotivoMovimiento, "IdMotivoMovimiento", "Descripcion");
        }
        private SelectList listaSeleccionUsuarios()
        {
            //Lista de Usuarios
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            IEnumerable<Usuario> listaUsuario = _ServiceUsuario.GetAllUsersEstadoSistemaId(1);
            return new SelectList(listaUsuario, "IdUsuario", "Nombre");
        }
    }
}