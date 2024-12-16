using DataAccessInterface;
using DataAccessInterface.Gateways;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Classes
{
    public class Config : IConfig
    {
        public IFileDataAccess FileDataAccess { get; set; }
        public ISqlDataAccess SqlDataAccess { get; set; }
        public INotify Notification {  get; set; }
        public IOpenAIAPI OpenAIAPI { get; set; }
        private ApiKeyChain KeyChain { get; set; }
        public Config(INotify notify, IFileDataAccess fileDataAccess, ISqlDataAccess sqlDataAccess)
        {
            FileDataAccess = fileDataAccess;
            SqlDataAccess = sqlDataAccess;
            Notification = notify;
        }

        public void LoadApiKeyChain(IGetApiKeys getApiKeys)
        {
            KeyChain = new ApiKeyChain(getApiKeys);
        }

        public string GetOpenAIKey()
        {
            string Name = "OpenAI";
            return KeyChain.GetApiKey(Name);
        }

        public string GetOpenAIEmbeddingEndpoint()
        {
            string Name = "OpenAIEmbeddingEndpoint";
            return ConfigurationManager.AppSettings[Name] ?? string.Empty;
        }

        public string GetOpenAIGenerativeTextEndpoint()
        {
            string Name = "OpenAITextGenerationEndpoint";
            return ConfigurationManager.AppSettings[Name] ?? string.Empty;
        }

        public string GetApiKeyDictonaryPath()
        {
            string Name = "APIKeyDictionaryFilePath";
            return ConfigurationManager.AppSettings[Name] ?? string.Empty;
        }


    }
}
