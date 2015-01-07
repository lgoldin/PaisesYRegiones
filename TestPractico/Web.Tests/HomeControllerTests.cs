namespace Web.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
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
    }
}
