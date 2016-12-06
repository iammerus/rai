using System.ServiceProcess;

namespace Rai.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun = new ServiceBase[]
            {
                new Rai()
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}
