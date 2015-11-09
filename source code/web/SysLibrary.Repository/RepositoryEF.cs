using SysLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Repository
{
    public class RepositoryEF : IRepository
    {
        private DbContext context = null;

        public RepositoryEF()
        {
            context = new Context();
        }

        public void Save<TEntidade>(TEntidade entity) where TEntidade : Entities.Base.BaseEntity
        {
            if (entity.Id > 0)
                context.Entry(entity).State = EntityState.Modified;
            else
                context.Set<TEntidade>().Add(entity);
        }

        public IQueryable<TEntidade> GetAll<TEntidade>() where TEntidade : Entities.Base.BaseEntity
        {
            return context.Set<TEntidade>().AsQueryable();
        }

        public IQueryable<TEntidade> GetAll<TEntidade>(System.Linq.Expressions.Expression<Func<TEntidade, bool>> predicado) where TEntidade : Entities.Base.BaseEntity
        {
            return context.Set<TEntidade>().Where(predicado).AsQueryable();
        }

        public TEntidade GetById<TEntidade>(int? id) where TEntidade : Entities.Base.BaseEntity
        {
            return context.Set<TEntidade>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
