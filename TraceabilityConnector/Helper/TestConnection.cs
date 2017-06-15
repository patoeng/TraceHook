
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace TraceabilityConnector.Helper
{
    public static  class TestConnection
    {
        public static bool PingNow(string ipAddress)
        {
            try
            {
                using (Ping pingSender = new Ping())
                {
                    IPAddress address = IPAddress.Parse(ipAddress);
                    PingReply reply = pingSender.Send(address,1000);

                    return reply != null && reply.Status == IPStatus.Success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ParseIpAddress(string data)
        {
            var j = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            var k = j.Match(data);
            return k.Value;
        }
    }

}
