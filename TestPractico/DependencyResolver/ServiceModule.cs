namespace DependencyResolver
{
    using Domain;
    using Ninject.Modules;
    using Repository;

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.BindService();
        }

        private void BindService()
        {
            this.Bind<IRegionRepository>().To<RegionRepository>();
            this.Bind<IPaisRepository>().To<PaisRepository>();
        }
    }
}
