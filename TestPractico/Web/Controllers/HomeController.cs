namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Domain;
    using Entities;
    using Repository;
    using Web.Models;

    public class HomeController : Controller
    {
        public HomeController()
        {
            this.RegionRepository = new RegionRepository();
            this.PaisRepository = new PaisRepository();
        }

        public IRegionRepository RegionRepository { get; set; }

        public IPaisRepository PaisRepository { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            IList<Region> regiones = this.RegionRepository.GetAll();
            Pais pais = this.PaisRepository.GetAll().FirstOrDefault();

            return this.View(new HomeModel { Regiones = regiones, PaisSeleccionado = pais });
        }

        [HttpPost]
        public JsonResult GetPaisesFromRegion(long idRegion)
        {
            IList<Pais> paises = this.PaisRepository.GetAllBy(new Region { Id = idRegion });

             var jsonData = from item in paises
                           select new
                           {
                               Codigo = item.Codigo,
                               Region = item.Region.Nombre,
                               Pais = item.Nombre,
                               Poblacion = item.Poblacion.HasValue ? item.Poblacion.Value.ToString("N2") : "NHI",
                               PBI = item.PBI.HasValue ? item.PBI.Value.ToString("N2") : "NHI",
                               PBICapita = item.Poblacion.HasValue && item.PBI.HasValue ? (item.PBI.Value / item.Poblacion.Value).ToString("N2") : "NHI",
                               Relevamiento = item.FechaRelevamiento.ToShortDateString()
                           };

            return this.Json(jsonData, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetPaises()
        {
            IList<Pais> paises = this.PaisRepository.GetAll();

            var jsonData = from item in paises
                           select new
                           {
                               Codigo = item.Codigo,
                               Region = item.Region.Nombre,
                               Pais = item.Nombre,
                               Poblacion = item.Poblacion.HasValue ? item.Poblacion.Value.ToString("N2") : "NHI",
                               PBI = item.PBI.HasValue ? item.PBI.Value.ToString("N2") : "NHI",
                               PBICapita = item.Poblacion.HasValue && item.PBI.HasValue ? (item.PBI.Value / item.Poblacion.Value).ToString("N2") : "NHI",
                               Relevamiento = item.FechaRelevamiento.ToShortDateString()
                           };

            return this.Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
