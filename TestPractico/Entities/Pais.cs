namespace Entities
{
    using System;

    public class Pais
    {
        public virtual string Codigo { get; set; }

        public virtual string Nombre { get; set; }

        public virtual Region Region { get; set; }

        public virtual string Image { get; set; }

        public virtual double? Poblacion { get; set; }

        public virtual double? PBI { get; set; }

        public virtual DateTime FechaRelevamiento { get; set; }

        public virtual string Texto { get; set; }

        public virtual string Capital { get; set; }

        public virtual string PrefijoTel { get; set; }

        public virtual string Presidente { get; set; }

        public virtual string Himno { get; set; }

        public virtual string Provincia { get; set; }
    }
}
