namespace Web.Models
{
    using System.Collections.Generic;
    using Entities;

    public class HomeModel
    {
        public IList<Region> Regiones { get; set; }

        public Region RegionSeleccionada { get; set; }

        public Pais PaisSeleccionado { get; set; }
    }
}