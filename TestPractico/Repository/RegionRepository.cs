namespace Repository
{
    using System.Collections.Generic;
    using Domain;
    using Entities;

    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public IList<Region> GetAll()
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.QueryOver<Region>().List<Region>();
            }
        }
    }
}
