﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Web.Util
{
    public class Util
    {
        public static void ValidateErrors(Controller pController)
        {

            var listaErrores = pController.ModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();

            foreach (ModelErrorCollection item in listaErrores)
            {
                if (item.Count > 0)
                    pController.ModelState.AddModelError("", item[0].ErrorMessage.ToString());
            }

        }


        public static List<string> GetModelStateErrors(ModelStateDictionary pModelState)
        {

            List<string> lista = new List<string>();

            var listaErrores = pModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();

            foreach (var item in pModelState)
            {
                lista.Add(item.Value.Errors[0].ErrorMessage);
            }


            return lista;

        }
        //COMENTARIOS 
        //Comando para inicializar los identities en una tabla SQLServer: DBCC CHECKIDENT('Color',RESEED,1)
        //using System.ComponentModel.DataAnnotations;
        // , id = "myForm", onsubmit = "event.preventDefault(),sweetConfirm()"
        //[MetadataType(typeof(CalificacionUsuarioMetadata))]


        //Cadena de conexión sólo para Alfredo
  //    <connectionStrings>
  //        <add name = "AuronMkEntities" connectionString="metadata=res://*/Models.MyModel_AurumMK.csdl|res://*/Models.MyModel_AurumMK.ssdl|res://*/Models.MyModel_AurumMK.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-VO65JJE\ALFREDOSQL;initial catalog=AuronMk;user id=sa;password=.;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  //    </connectionStrings>
    }
}
