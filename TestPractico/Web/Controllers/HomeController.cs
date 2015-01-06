namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Domain;
    using Entities;
    using Models;
    using Repository;

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
            Region region = regiones.First();
            Pais pais = region.Paises.First();

            return this.View(new HomeModel { Regiones = regiones, PaisSeleccionado = pais, RegionSeleccionada = region });
        }

        [HttpPost]
        public JsonResult GetPaisesByRegion(long idRegion)
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

        [HttpPost]
        public JsonResult GetPaisByCodigo(string codigo)
        {
            Pais pais = this.PaisRepository.GetBy(codigo);

            var jsonData = from item in new List<Pais> { pais }
                           select new
                           {
                               Codigo = item.Codigo,
                               Image = item.Image,
                               Nombre = item.Nombre,
                               Texto = item.Texto,
                               Capital = item.Capital,
                               PrefijoTel = item.PrefijoTel,
                               Presidente = item.Presidente,
                               Himno = item.Himno,
                               Poblacion = item.Poblacion.HasValue ? item.Poblacion.Value.ToString("N2") : "NHI",
                               Provincias = item.Provincia
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
