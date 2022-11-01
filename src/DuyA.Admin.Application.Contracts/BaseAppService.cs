using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DuyA.Admin
{
    public interface BaseAppService<T> where T : class
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<T>> GetListAsync(CancellationToken cancellationToken = default);
    }
}
