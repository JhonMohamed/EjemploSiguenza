using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T2.Entity;
using T2.MainModel;
using T2.SQLServer;

namespace EjemploSiguenza.Controllers
{
    public class ViajesController : Controller
    {
        private readonly SP_Viaje_DL viajeDl = new SP_Viaje_DL();
        

        [HttpGet]
        public ActionResult ListadoViajes()
        {
            var viajes = viajeDl.ListaViaje("C002",2022);
            var ViajeViewModel = new ViajesViewModele()
            {
                Viajes = viajes,
            };

            return View(ViajeViewModel);
        }
    }
}