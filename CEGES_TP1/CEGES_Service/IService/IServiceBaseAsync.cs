using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Services;

public interface IServiceBaseAsync<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task EditAsync(T entity);

}
