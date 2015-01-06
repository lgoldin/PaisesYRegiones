namespace Domain
{
    using System.Collections.Generic;
    using Entities;

    public interface IRegionRepository
    {
        IList<Region> GetAll();
    }
}
