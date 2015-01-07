namespace Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Controllers;
    using Domain;
    using Entities;
    using Models;
    using Moq;
    using NUnit.Framework;
    
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexWorksWell()
        {
            var regionRepository = new Mock<IRegionRepository>();
            regionRepository.Setup(x => x.GetAll()).Returns(new List<Region>
                                                                {
                                                                    new Region
                                                                        {
                                                                            Id = 3543,
                                                                            Nombre = "Region",
                                                                            Paises = new List<Pais>
                                                                                         {
                                                                                             new Pais
                                                                                                 {
                                                                                                     Codigo = "AR",
                                                                                                     Nombre = "Argentina"
                                                                                                 }
                                                                                         }
                                                                        }
                                                                });

            var controller = new HomeController(regionRepository.Object, null);

            ActionResult result = controller.Index();
            var viewResult = (ViewResult)result;
            var model = (HomeModel)viewResult.Model;
            
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.PaisSeleccionado);
            Assert.IsNotNull(model.RegionSeleccionada);
            Assert.IsNotNull(model.Regiones);
            Assert.AreEqual(1, model.Regiones.Count);
            Assert.AreEqual(3543, model.Regiones.ElementAt(0).Id);
            Assert.AreEqual("Region", model.Regiones.ElementAt(0).Nombre);
            Assert.AreEqual(1, model.Regiones.ElementAt(0).Paises.Count);
            Assert.AreEqual(1, model.Regiones.ElementAt(0).Paises.Count);
            Assert.AreEqual("AR", model.PaisSeleccionado.Codigo);
            Assert.AreEqual("Argentina", model.PaisSeleccionado.Nombre);
            Assert.AreEqual(3543, model.RegionSeleccionada.Id);
            Assert.AreEqual("Region", model.RegionSeleccionada.Nombre);

            regionRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetPaisesByRegionReturnJsonOk()
        {
            var paisRepository = new Mock<IPaisRepository>();
            paisRepository.Setup(x => x.GetAllBy(It.Is<Region>(y => y.Id == 543))).Returns(new List<Pais>
                                                                                               {
                                                                                                   new Pais
                                                                                                       {
                                                                                                           Codigo = "AR",
                                                                                                           Nombre = "Argentina",
                                                                                                           Region = new Region { Nombre = "Sudamerica" },
                                                                                                           Poblacion = 123456789,
                                                                                                           PBI = null,
                                                                                                           FechaRelevamiento = DateTime.Now
                                                                                                       }
                                                                                               });

            var controller = new HomeController(null, paisRepository.Object);

            JsonResult result = controller.GetPaisesByRegion(543);
            
            Assert.IsNotNull(result);
            
            paisRepository.Verify(x => x.GetAllBy(It.Is<Region>(y => y.Id == 543)), Times.Once);
        }

        [Test]
        public void GetPaisByCodigoReturnJsonOk()
        {
            var paisRepository = new Mock<IPaisRepository>();
            paisRepository.Setup(x => x.GetBy("AR")).Returns(new Pais
                                                                 {
                                                                     Codigo = "AR",
                                                                     Nombre = "Argentina",
                                                                     Region = new Region { Nombre = "Sudamerica" },
                                                                     Poblacion = 123456789,
                                                                     PBI = null,
                                                                     FechaRelevamiento = DateTime.Now
                                                                 });

            var controller = new HomeController(null, paisRepository.Object);

            JsonResult result = controller.GetPaisByCodigo("AR");

            Assert.IsNotNull(result);

            paisRepository.Verify(x => x.GetBy("AR"), Times.Once);
        }

        [Test]
        public void EliminarPaisByCodigoReturnsError()
        {
            var controller = new HomeController(null, null);

            JsonResult result = controller.EliminarPaisByCodigo("Texto largo");
            var resultWrapper = (IDictionary<string, object>)new RouteValueDictionary(result.Data);
            Assert.AreEqual(false, resultWrapper["success"]);
            Assert.AreEqual("No hay ningun pais para borrar", resultWrapper["message"]);
        }

        [Test]
        public void EliminarPaisByCodigoReturnsSuccess()
        {
            var pais = new Pais
                           {
                               Codigo = "BR",
                               Region = new Region { Id = 987, Nombre = "Sudamerica" }
                           };

            var paisRepository = new Mock<IPaisRepository>();
            paisRepository.Setup(x => x.GetBy("BR")).Returns(pais);
            
            var controller = new HomeController(null, paisRepository.Object);

            JsonResult result = controller.EliminarPaisByCodigo("BR");
            var resultWrapper = (IDictionary<string, object>)new RouteValueDictionary(result.Data);
            
            Assert.AreEqual(true, resultWrapper["success"]);
            Assert.AreEqual(987, resultWrapper["idRegion"]);

            paisRepository.Verify(x => x.GetBy("BR"), Times.Once);
            paisRepository.Verify(x => x.Delete(pais), Times.Once);
        }

        [Test]
        public void UpdatePaisError()
        {
            var controller = new HomeController(null, null);
            controller.ModelState.AddModelError(string.Empty, "Error");
            
            JsonResult result = controller.UpdatePais(new PaisModel());
            var resultWrapper = (IDictionary<string, object>)new RouteValueDictionary(result.Data);

            Assert.AreEqual(false, resultWrapper["success"]);
        }

        [Test]
        public void UpdatePaisSuccess()
        {
            var region = new Region { Id = 987, Nombre = "Sudamerica" };

            var pais = new Pais
            {
                Codigo = "BR",
                Region = region
            };

            var paisRepository = new Mock<IPaisRepository>();
            paisRepository.Setup(x => x.GetBy("BR")).Returns(pais);
            
            var controller = new HomeController(null, paisRepository.Object);

            JsonResult result = controller.UpdatePais(new PaisModel
                                                          {
                                                              Codigo = "BR",
                                                              Capital = "Capital",
                                                              Himno = "Himno",
                                                              Poblacion = 123456789,
                                                              PrefijoTel = "PrefijoTel",
                                                              Presidente = "Presidente",
                                                              Provincia = "Provincia",
                                                              Texto = "Texto"
                                                          });

            var resultWrapper = (IDictionary<string, object>)new RouteValueDictionary(result.Data);

            Assert.AreEqual(true, resultWrapper["success"]);
            Assert.AreEqual(987, resultWrapper["idRegion"]);

            paisRepository.Verify(x => x.Update(It.Is<Pais>(y => y.Region == region && y.Codigo == "BR" && y.Capital == "Capital" && y.Himno == "Himno" && y.Poblacion == 123456789 && y.PrefijoTel == "PrefijoTel" && y.Presidente == "Presidente" && y.Provincia == "Provincia" && y.Texto == "Texto")), Times.Once);
        }
    }
}
