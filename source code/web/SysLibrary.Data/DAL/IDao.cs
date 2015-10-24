using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.Data.DAL
{
    /// <summary>
    /// Abstract interface what contains methods the crud
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDao<T> 
        where T : DTO
    {
        /// <summary>
        /// Insert a new object
        /// </summary>
        /// <param name="obj"></param>
        void Insert(T obj);

        /// <summary>
        /// Update a object
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);

        /// <summary>
        /// Remove a object
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Return a object specific by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Return a collection to objects
        /// </summary>
        /// <returns></returns>
        List<T> Get();

        /// <summary>
        /// Return the number to objects what the collection have
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
