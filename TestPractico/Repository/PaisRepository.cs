namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Entities;
    using NHibernate.Linq;

    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public IList<Pais> GetAllBy(Region region)
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.QueryOver<Pais>().Where(x => x.Region.Id == region.Id).OrderBy(x => x.Region.Id).Asc.OrderBy(x => x.Nombre).Asc.List<Pais>();
            }
        }

        public Pais GetBy(string codigo)
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.Query<Pais>().FirstOrDefault(x => x.Codigo == codigo);
            }
        }

        public void Delete(Pais pais)
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                using (var scope = session.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        session.Delete(pais);
                        scope.Commit();
                    }
                    catch (Exception exception)
                    {
                        scope.Rollback();
                        throw exception;
                    }
                }
            }
        }

        public void Update(Pais pais)
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                using (var scope = session.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        session.Update(pais);
                        scope.Commit();
                    }
                    catch (Exception exception)
                    {
                        scope.Rollback();
                        throw exception;
                    }
                }
            }
        }
    }
}
