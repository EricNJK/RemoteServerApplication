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
        /// <summary>
        /// Remote server entry point
        /// </summary>
        /// <remarks>
        /// This server listens on tcp port 50000.
        /// Only one service is registered to serve requests for the <see cref="PTSLibrary.PTSAdminFacade"/> class.
        /// Only one instance (Singleton mode) of the facade is allowed per client (Admin Application)
        /// Server runs until Enter key is pressed.
        /// </remarks>
        /// <param name="args"></param>
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
