using System;
using System.Configuration;

namespace CollectNetworkTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int duration = Convert.ToInt32(ConfigurationManager.AppSettings["Duration"]);
                var config = NetworkTraceConfiguation.GetConfiguration();
                var authToken = AuthService.GetAcccessToken(config);
                var armService = new ArmService(config, authToken);
                Utility.Trace($"Chosen duration for Network Trace = {duration}");
                armService.StartNetworkTrace(duration);
            }
            catch (Exception ex)
            {
                Utility.Trace($"Exception while running the tool {ex.GetType()}:{ex.Message} {Environment.NewLine} {ex.StackTrace}");
            }
            finally
            {
                Utility.FlushTrace();
            }
        }
    }
}
