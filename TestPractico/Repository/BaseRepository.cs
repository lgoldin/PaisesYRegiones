namespace Repository
{
    using NHibernate;
    using NHibernate.Configuration;

    public abstract class BaseRepository<T> where T : class
    {
        protected ISessionFactory SessionFactory
        {
            get
            {
                return NHibernateFactory.Get();
            }
        }
    }
}
