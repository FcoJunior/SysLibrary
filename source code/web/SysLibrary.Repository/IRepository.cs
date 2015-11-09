using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Repository
{
    public interface IRepository : IDisposable
    {
        void Save<TEntidade>(TEntidade entidade) where TEntidade : BaseEntity;

        IQueryable<TEntidade> GetAll<TEntidade>() where TEntidade : BaseEntity;

        IQueryable<TEntidade> GetAll<TEntidade>(Expression<Func<TEntidade, bool>> predicado) where TEntidade : BaseEntity;

        TEntidade GetById<TEntidade>(int? id) where TEntidade : BaseEntity;

        void Commit();
    }
}
