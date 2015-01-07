namespace Domain
{
    using System.Collections.Generic;
    using Entities;

    public interface IPaisRepository
    {
        IList<Pais> GetAllBy(Region region);

        Pais GetBy(string codigo);

        void Delete(Pais pais);

        void Update(Pais pais);
    }
}
