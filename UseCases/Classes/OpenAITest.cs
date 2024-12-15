using DataAccessInterface.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Classes
{
    public class OpenAITest
    {
        private IOpenAIAPI _api {  get; set; }
        public OpenAITest(IOpenAIAPI api)
        {
            _api = api;
        }

        public async Task<string> GetData(string Prompt)
        {
            return await _api.GenerateText(Prompt);
        }
    }
}
