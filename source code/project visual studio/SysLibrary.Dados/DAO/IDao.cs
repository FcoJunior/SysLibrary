using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SysLibrary.Entidades.DTO;

namespace SysLibrary.Dados
{
    /// <summary>
    /// Interface das funções básicas das classes DAO
    /// </summary>
    public interface IDao<T> where T : DTO
    {
        /// <summary>
        /// Método para inserção de registros
        /// </summary>
        /// <param name="obj"></param>
        void Insert(T obj);

        /// <summary>
        /// Método para atualização de registros
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);

        /// <summary>
        /// Método para remoção de registros
        /// </summary>
        /// <param name="obj"></param>
        void Delete(T obj);

        /// <summary>
        /// Método para consulta de registros
        /// </summary>
        /// <returns></returns>
        List<T> Get();

        /// <summary>
        /// Método para cnsulta de um registro específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Método que retorna o numero de registros da entidade
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
