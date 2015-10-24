using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Data.DAL
{
    public interface IDao<T> 
        where T : DTO
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T Get(int id);
        List<T> Get();
        int Count();
    }
}
