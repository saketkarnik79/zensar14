using Web_DemoASPNETCoreBasics2.Services.Contracts;

namespace Web_DemoASPNETCoreBasics2.Services
{
    public class DataServiceV1: IDataService
    {
        public string GetData()
        {
            return "Data from DataServiceV1";
        }
    }
}
