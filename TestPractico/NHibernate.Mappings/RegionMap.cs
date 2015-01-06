namespace NHibernate.Mappings
{
    using Entities;
    using Mapping.ByCode;
    using Mapping.ByCode.Conformist;
    
    public class RegionMap : ClassMapping<Region>
    {
        public RegionMap()
        {
            this.Lazy(false);
            this.Id(x => x.Id, map => map.Generator(Generators.Identity));
            this.Property(x => x.Nombre, map => map.NotNullable(true));
            this.Bag(p => p.Paises, map => { map.Lazy(CollectionLazy.NoLazy); map.Key(k => k.Column("RegionId")); map.Table("Pais"); }, rel => rel.OneToMany(x => x.Class(typeof(Pais))));
        }
    }
}
