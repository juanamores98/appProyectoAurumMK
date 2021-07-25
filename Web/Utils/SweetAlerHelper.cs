using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Utils
{
    public class SweetAlerHelper
    {
        public static string Mensaje(string titulo, string mensaje, SweetAlertMessageType tipoMensaje)
        {
            return "swal('Hello world!');";
        }

        public enum SweetAlertMessageType
        {
            warning, error, success, info
        }
    }
}
