using SysLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SysLibrary.Business.Base
{
    public class BaseBO
    {
        //IRepository repositorio = SysLibrary.Repository.Factory.GetInstance();
        
        public static void Save<TEntidade>(TEntidade entity) where TEntidade : BaseEntity
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            entity.Ativo = true;
            repositorio.Save<TEntidade>(entity);
            repositorio.Commit();
        }

        public static IList<TEntidade> GetAllActive<TEntidade>() where TEntidade : BaseEntity
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            return repositorio.GetAll<TEntidade>(x => x.Ativo).ToList();
        }

        public static IList<TEntidade> GetAllActive<TEntidade>(Expression<System.Func<TEntidade, bool>> predicado) where TEntidade : BaseEntity
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            return repositorio.GetAll<TEntidade>(predicado).Where(x => x.Ativo).ToList();
        }

        public static TEntidade Find<TEntidade>(int? id) where TEntidade : BaseEntity
        {
            var repositorio = SysLibrary.Repository.Factory.GetInstance();
            return repositorio.GetById<TEntidade>(id);
        }

        public static void Remove<TEntidade>(int id) where TEntidade : BaseEntity
        {
            using (var repositorio = SysLibrary.Repository.Factory.GetInstance())
            {
                var entidade = repositorio.GetById<TEntidade>(id);
                entidade.Ativo = false;
                repositorio.Save<TEntidade>(entidade);
                repositorio.Commit();
            }
        }

    }
}
