namespace NHibernate.Mappings
{
    using Entities;
    using Mapping.ByCode;
    using Mapping.ByCode.Conformist;
    
    public class PaisMap : ClassMapping<Pais>
    {
        public PaisMap()
        {
            this.Lazy(false);
            this.Id(x => x.Codigo, map => map.Length(2));
            this.Property(x => x.Capital, map => map.NotNullable(true));
            this.Property(x => x.FechaRelevamiento, map => map.NotNullable(true));
            this.Property(x => x.Himno, map => map.NotNullable(true));
            this.Property(x => x.Image, map => map.NotNullable(true));
            this.Property(x => x.Nombre, map => map.NotNullable(true));
            this.Property(x => x.PBI, map => map.NotNullable(false));
            this.Property(x => x.Poblacion, map => map.NotNullable(false));
            this.Property(x => x.PrefijoTel, map => map.NotNullable(true));
            this.Property(x => x.Presidente, map => map.NotNullable(true));
            this.Property(x => x.Provincia, map => map.NotNullable(true));
            this.Property(x => x.Texto, map => map.NotNullable(true));
            this.ManyToOne(x => x.Region, map => map.Column("RegionId"));
        }
    }
}
