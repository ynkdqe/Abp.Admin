using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Application.Services;

namespace DuyA.Admin.UserOtps
{
    public interface IUserOtpAppService : //ICrudAppService<UserOtpDto, int, UserOtpDto, UserOtpInputDto, UserOtpUpdateDto> 
        IApplicationService//, BaseAppService<UserOtpDto>
    {
        Task<UserOtpDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<UserOtpDto>> GetListAsync(CancellationToken cancellationToken = default);
    }
}
