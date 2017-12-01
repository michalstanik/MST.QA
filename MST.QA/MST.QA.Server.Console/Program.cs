using MST.QA.Server.Managers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM = System.ServiceModel;

namespace MST.QA.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting up services...");
            System.Console.WriteLine("");

            SM.ServiceHost hostProjectManager = new SM.ServiceHost(typeof(ProjectManager));

            StartService(hostProjectManager, "ProjectManager");

            System.Console.WriteLine("");
            System.Console.WriteLine("Press [Enter] to exit.");
            System.Console.ReadLine();

            StopService(hostProjectManager, "ProjectManager");
            System.Console.ReadLine();
        }


        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();
            System.Console.WriteLine("Service {0} started.", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                System.Console.WriteLine(string.Format("Listening on endpoint:"));
                System.Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                System.Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                System.Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }

            System.Console.WriteLine();
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            System.Console.WriteLine("Service {0} stopped.", serviceDescription);
        }
    }
}
