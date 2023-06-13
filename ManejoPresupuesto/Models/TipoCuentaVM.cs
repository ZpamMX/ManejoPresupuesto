using ManejoPresupuesto.Validaciones;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Web.Mvc;

namespace ManejoPresupuesto.Models
{
    public class TipoCuentaVM
    {
        public int Id { get; set; }

        //[Display(Name = "Nombre del tipo cuenta")]
        [Required (ErrorMessage ="El campo {0} es requerido")]

        [Remote(action:"VerificarExisteTipoCuenta", controller:"TiposCuentas")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }
    }
}
