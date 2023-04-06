using AdminSSO.GPTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSSO.ChatGPTControllers
{
    public class GPTController : AdminSSOController, IGPTAppService
    {
        private IGPTAppService _gpt;
        public GPTController(IGPTAppService gpt) 
        {
            _gpt = gpt;
        }
        //public async Task<GPTResponseDto> ChatGPT(string query)
        //{
        //    return await _gpt.ChatGPT(query);
        //}
    }
}
