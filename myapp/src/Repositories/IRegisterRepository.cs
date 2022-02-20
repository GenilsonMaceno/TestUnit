using System.Collections.Generic;
using src.Entities;

namespace src.Repositories
{
    public interface IRegisterRepository
    {
        ICollection<EntityPerson> Get();
        ICollection<EntityPerson> GetById(int id);
        bool Add (EntityPerson entityPerson);
        bool Update(EntityPerson entityPerson);
        bool Delete (int id);
    }
}