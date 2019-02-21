using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;

namespace RemoteServerApplication
{
    /// <summary>
    /// .Net Remoting service for AdminApplication.
    /// </summary>
    /// 
    /// <remarks> This console application provides remoting service for the Admin Application. </remarks>

    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(50000);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PTSLibrary.PTSAdminFacade),
                "PTSAdminFacade", WellKnownObjectMode.Singleton);
            Console.WriteLine("Press return key to terminate server");
            Console.ReadLine();
        }
    }
}
