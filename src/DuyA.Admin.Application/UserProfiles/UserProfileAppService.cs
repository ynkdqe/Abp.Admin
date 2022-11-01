using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Validation;

namespace DuyA.Admin.UserProfiles
{
    public class UserProfileAppService : AdminAppService, IValidationEnabled//, IUserProfileAppService
    {
        IUserProfileRepository _userProfileRepository;

        public UserProfileAppService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public Task<UserProfileDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserProfileDto>> GetListAsync(CancellationToken cancellationToken = default)
        {
            var list = await _userProfileRepository.GetListAsync();
            return ObjectMapper.Map<List<UserProfile>, List<UserProfileDto>>(list);
        }
    }
}
