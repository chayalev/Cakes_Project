using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ServiceHost host = new ServiceHost(typeof(WcfServer.Client));
            host.Open();
            ServiceHost host2 = new ServiceHost(typeof(WcfServer.Manager));
            host2.Open(); 
            Console.WriteLine("This is Server");
            Console.ReadLine(); 

        }
    }
}
