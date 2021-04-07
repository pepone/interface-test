using Ice;
using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using var communicator = Util.initialize();

            Console.CancelKeyPress += (sender, eventArgs) => communicator.destroy();

            var server = communicator.createObjectAdapterWithEndpoints("server", "tcp -h localhost -p 10000");
            server.add(new RangerAccessRequest(), Ice.Util.stringToIdentity("test"));
            server.activate();
            communicator.waitForShutdown();
        }
    }

    class RangerAccessRequest : Test.RangerAccessRequestDisp_
    {
        public override Value getResource(Current current = null) => new Test.RangerAccessResourceImp();
    }
}
