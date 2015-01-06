namespace Domain
{
    using System.Collections.Generic;
    using Entities;

    public interface IPaisRepository
    {
        IList<Pais> GetAllBy(Region region);

        IList<Pais> GetAll();
    }
}
