using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Validation;

namespace DuyA.Admin.UserOtps
{
    public class UserOtpAppService : AdminAppService, IUserOtpAppService//, IValidationEnabled
    {
        IUserOtpRepository _userOtpRepository;

        public UserOtpAppService(IUserOtpRepository userOtpRepository)
        {
            _userOtpRepository = userOtpRepository;
        }

        public Task<UserOtpDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserOtpDto>> GetListAsync(CancellationToken cancellationToken = default)
        {
            var list = _userOtpRepository.GetAll();
            var result = ObjectMapper.Map<List<UserOtp>, List<UserOtpDto>>(list);
            return Task.FromResult(result);
        }
    }
}
