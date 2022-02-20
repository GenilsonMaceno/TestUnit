using System;
using System.Collections.Generic;
using System.Linq;
using src.Context;
using src.Entities;

namespace src.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext _appDbContext;

        public RegisterRepository (AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }
        public bool Add(EntityPerson entityPerson)
        {
            try
            {
                if (entityPerson == null)
                {
                     return false;
                }

                _appDbContext.Add(entityPerson);
                _appDbContext.SaveChanges();
                return true;
                
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (!id.ToString().Any())
                {
                    return false;
                }
                
                var entityPerson = _appDbContext.Entities.Where(ent => ent.Entity == id).DefaultIfEmpty();
                _appDbContext.Remove(entityPerson);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public ICollection<EntityPerson> Get()
        {
            try
            {
                var entityPerson = _appDbContext.Entities.ToList();
                return entityPerson;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<EntityPerson> GetById(int id)
        {
            try
            {
                    if (!id.ToString().Any())
                    {
                        return null;
                    }
                    
                    var entityPerson = _appDbContext.Entities.Where(ent => ent.Entity == id).DefaultIfEmpty();
                    return entityPerson.ToList();
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public bool Update(EntityPerson entityPerson)
        {
            try
            {
                if (entityPerson == null)
                {
                    return false;
                }

                _appDbContext.Update(entityPerson);
                _appDbContext.SaveChanges();
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}