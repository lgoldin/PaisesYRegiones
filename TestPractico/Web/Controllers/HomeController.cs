namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Domain;
    using Entities;
    using Models;

    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public HomeController(IRegionRepository regionRepository, IPaisRepository paisRepository)
        {
            this.RegionRepository = regionRepository;
            this.PaisRepository = paisRepository;
        }

        public IRegionRepository RegionRepository { get; set; }

        public IPaisRepository PaisRepository { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            IList<Region> regiones = this.RegionRepository.GetAll();
            Region region = regiones.First();
            Pais pais = region.Paises.FirstOrDefault();

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
                               Poblacion = item.Poblacion.HasValue ? (item.Poblacion.Value / 1000000).ToString("N2") : "NHI",
                               PBI = item.PBI.HasValue ? (Math.Round(item.PBI.Value / 1000, 0) * 1000).ToString("N0") : "NHI",
                               PBICapita = item.Poblacion.HasValue && item.PBI.HasValue ? (item.PBI.Value / item.Poblacion.Value).ToString("N2") : "NHI",
                               Relevamiento = item.FechaRelevamiento.ToString("MM/dd/yyyy")
                           };

            return this.Json(jsonData, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetPaisByCodigo(string codigo)
        {
            Pais pais = this.PaisRepository.GetBy(codigo);
            
            var paises = pais != null ? new List<Pais> { pais } : new List<Pais>();
            var jsonData = from item in paises
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
                               Poblacion = item.Poblacion.HasValue ? string.Format("{0} millones ({1})", (item.Poblacion.Value / 1000000).ToString("N2"), item.FechaRelevamiento.ToString("yyyy")) : "NHI",
                               Provincias = item.Provincia
                           };

            return this.Json(jsonData, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult EliminarPaisByCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo) || codigo.Length != 2)
            {
                return this.Json(new { success = false, message = "No hay ningun pais para borrar" }, JsonRequestBehavior.DenyGet);
            }

            Pais pais = this.PaisRepository.GetBy(codigo);
            
            Region region = pais.Region;

            this.PaisRepository.Delete(pais);

            return this.Json(new { success = true, idRegion = region.Id }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult ModificarPais(string codigo)
        {
            Pais pais = this.PaisRepository.GetBy(codigo);

            var model = new PaisModel
                            {
                                Codigo = pais.Codigo,
                                Capital = pais.Capital,
                                PrefijoTel = pais.PrefijoTel,
                                Presidente = pais.Presidente,
                                Himno = pais.Himno,
                                Poblacion = pais.Poblacion,
                                Provincia = pais.Provincia,
                                Texto = pais.Texto
                            };

            return this.PartialView("ModificarPais", model);
        }

        [HttpPost]
        public JsonResult UpdatePais(PaisModel model)
        {
            if (ModelState.IsValid)
            {
                Pais pais = this.PaisRepository.GetBy(model.Codigo);
                pais.Capital = model.Capital;
                pais.PrefijoTel = model.PrefijoTel;
                pais.Presidente = model.Presidente;
                pais.Himno = model.Himno;
                pais.Poblacion = model.Poblacion;
                pais.Provincia = model.Provincia;
                pais.Texto = model.Texto;

                this.PaisRepository.Update(pais);

                return this.Json(new { success = true, idRegion = pais.Region.Id }, JsonRequestBehavior.DenyGet);
            }

            return this.Json(new { success = false }, JsonRequestBehavior.DenyGet);
        }
    }
}
