using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Classes;
using DataAccessInterface;
using System.Configuration;
using DataAccessInterface.Gateways;

namespace UseCases.Classes
{
    
    public class ApiKeyChain : Database<string, string>
    {
        private IGetApiKeys _api { get;set; }
        public ApiKeyChain(IGetApiKeys api)
        {
            _api = api;
            LoadInitalDataFromAPI();
        }

        public string GetApiKey(string key)
        {
            return this.GetData(key);
        }

        public Dictionary<string,string> GetAllApiKeys()
        {
            return this.GetData();
        }

        public void Add(string ApiName, string ApiKey)
        {
            try
            {
                this.Insert(ApiName, ApiKey);
            }
            catch
            {
                throw;
            }
        }

        public void Add(IEnumerable<KeyValuePair<string,string>> Data)
        {
            try
            {
                this.Insert(Data);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateKey(string ApiName, string ApiKey)
        {
            this.Update(ApiName, ApiKey);
        }

        public void ClearAll()
        {
            this.Clear();
        }

        private void LoadInitalDataFromAPI()
        {
            Add(_api.GetData());
        }

    }


}
