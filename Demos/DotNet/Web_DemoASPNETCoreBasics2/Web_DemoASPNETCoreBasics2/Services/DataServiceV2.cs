using Web_DemoASPNETCoreBasics2.Services.Contracts;

namespace Web_DemoASPNETCoreBasics2.Services
{
    public class DataServiceV2: IDataService
    {
        public string GetData()
        {
            return "Data from DataServiceV2";
        }
    }
}
