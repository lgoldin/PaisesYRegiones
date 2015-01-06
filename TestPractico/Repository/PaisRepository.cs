namespace Repository
{
    using System.Collections.Generic;
    using Domain;
    using Entities;

    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public IList<Pais> GetAllBy(Region region)
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.QueryOver<Pais>().Where(x => x.Region.Id == region.Id).List<Pais>();
            }
        }

        public IList<Pais> GetAll()
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.QueryOver<Pais>().List<Pais>();
            }
        }
    }
}
