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
        private readonly Chofer_DL choferDao = new Chofer_DL();
        private readonly Fecha_CL anio = new Fecha_CL();
        private readonly SP_VIAJES viajesDL = new SP_VIAJES();
        private readonly SP_Ruta rutaSP = new SP_Ruta();
        private readonly Bus_LP busLP = new Bus_LP();
        private readonly ViajesCRUDViewModel viajesCrudViewModel = new ViajesCRUDViewModel();



        [HttpGet]
        public ActionResult ListadoViajes(string cod_chof, int? hrs_sal)
        {
            var viajes = viajeDl.ListaViaje(cod_chof, hrs_sal);
            var chofers = choferDao.MostrarChofer();
            var fecha = anio.MostrarFecha();
            var ViajeViewModel = new ViajesViewModele()
            {
                Viajes = viajes,
                Chofers = chofers,
                Anio = fecha
            };

            return View(ViajeViewModel);
        }

        [HttpGet]
        public ActionResult ListadoCompletoViajes()
        {
            var viajarCompleto = viajesDL.ListarViajes();
            return View(viajarCompleto);
        }

        [HttpGet]
        public ActionResult EditarViajes(string nroViaje)
        {
            var viaje = viajesDL.ListarViajes().FirstOrDefault(v => v.NumeroViaje == nroViaje);
            var chofers = choferDao.MostrarChofer();
            var ruta = rutaSP.ListarRutas();
            var bus = busLP.ListarBuses();
            var viajesCrud = new ViajesCRUDViewModel()
            {
                Chofers = chofers,
                Rutas = ruta,
                Viajes = viaje,
                Bus = bus
            };
            return View(viajesCrud);
        }

        [HttpPost]
        public ActionResult EditarViajes(ViajesCRUDViewModel viajeCrudViewModel)
        {
        //    if (ModelState.IsValid)
        //    {
        //        viajesDL.SP_Editar_Viajes(
        //            viajeCrudViewModel.Viajes.NumeroViaje,      // Número de viaje
        //            viajeCrudViewModel.Viajes.,        // Número de bus (nullable)
        //            viajeCrudViewModel.Viajes.nro_pla,          // Número de placa
        //            viajeCrudViewModel.Viajes.NombreChofer,     // Código del chofer
        //            viajeCrudViewModel.Viajes.HoraSalida,       // Hora de salida
        //            viajeCrudViewModel.Viajes.CostoViaje,       // Costo del viaje (nullable)
        //            viajeCrudViewModel.Viajes.FechaViaje        // Fecha del viaje (nullable)
        //        );

        //        return RedirectToAction("ListadoCompletoViajes");
        //    }

        //    viajeCrudViewModel.Rutas = rutaSP.ListarRutas();
        //    viajeCrudViewModel.Chofers = choferDao.MostrarChofer();
            return View();
        }

        [HttpGet]
        public ActionResult DetallesViaje(string nroViaje)
        {
            var viaje = viajesDL.ListarViajes().FirstOrDefault(v => v.NumeroViaje == nroViaje);
            if (viaje == null)
            {
                return HttpNotFound();
            }

            var rutas = rutaSP.ListarRutas();
            var chofers = choferDao.MostrarChofer();

            var viajarCompleto = new ViajesCRUDViewModel { Viajes = viaje, Rutas = rutas, Chofers = chofers };

            return View(viajarCompleto);
        }

        [HttpGet]
        public ActionResult EliminarViaje(string NumeroViaje)
        {
            viajesDL.sp_EliminarViaje(NumeroViaje);
            return RedirectToAction("ListadoCompletoViajes");
        }
    }

}