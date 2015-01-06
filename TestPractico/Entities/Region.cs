namespace Entities
{
    using System.Collections.Generic;

    public class Region
    {
        public virtual long Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual IList<Pais> Paises { get; set; }
    }
}
