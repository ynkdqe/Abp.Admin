using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AdminSSO.GPTs
{
    public class GPTAppService : AdminSSOAppService, IGPTAppService
    {
        IConfiguration _configuration;
        public GPTAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public async Task<GPTResponseDto> ChatGPT(string query)
        //{
        //    var result = new GPTResponseDto();
        //    var openAiService = new OpenAIService(new OpenAiOptions()
        //    {
        //        ApiKey = _configuration.GetSection("ChatGPT:Token").Value
        //    });
        //    var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
        //    {
        //        Prompt = query,
        //        Model = Models.TextDavinciV2,
        //        MaxTokens = 4000
        //    });

        //    if (completionResult.Successful)
        //    {
        //        foreach (var item in completionResult.Choices)
        //        {
        //            result.Response += item.Text;
        //        }
        //    }
        //    else
        //    {
        //        if (completionResult.Error == null)
        //        {
        //            throw new Exception("Unknown Error");
        //        }
        //        result.Response = completionResult.Error.Code + " : " + completionResult.Error.Message;
        //    }
        //    return result;
        //}
    }
}
