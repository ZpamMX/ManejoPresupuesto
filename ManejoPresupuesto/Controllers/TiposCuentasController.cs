using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositoriosTiposCuentas repositoriosTiposCuentas;
        
        public TiposCuentasController(IRepositoriosTiposCuentas repositoriosTiposCuentas)
        {
            this.repositoriosTiposCuentas = repositoriosTiposCuentas;
        }
       
        [HttpPost]
        public async Task <IActionResult> Crear(TipoCuentaVM tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }
            tipoCuenta.UsuarioId = 1;

            var yaExiste = await repositoriosTiposCuentas.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

            if( yaExiste )
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre),$"El nombre  { tipoCuenta.Nombre} ya existe" );
                return View(tipoCuenta);
            }

            await repositoriosTiposCuentas.Crear(tipoCuenta);
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteTipoCuenta(string nombre)
        {
            var usuarioId = 1;
            var yaExisteTipoCuenta = await repositoriosTiposCuentas.Existe(nombre, usuarioId);

            if( yaExisteTipoCuenta)
            {
                return Json($"El nombre {nombre} ya existe");
            }
            return Json(true);
        }



    }
}
