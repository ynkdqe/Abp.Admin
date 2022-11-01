
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Application.Services;

namespace DuyA.Admin.UserProfiles
{
    public interface IUserProfileAppService : IApplicationService
    {
        Task<UserProfileDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<UserProfileDto>> GetListAsync(CancellationToken cancellationToken = default);

    }
}
