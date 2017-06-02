using System;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;

namespace ServicioDiario
{
    /*
     * El ejemplo se basa en una forma para depurar servicios windows de manera simple: https://stackoverflow.com/questions/125964/easier-way-to-debug-a-windows-service
     */
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[] 
            {
                new Service1()
            };

            if (Environment.UserInteractive)
            {
                RunInteractive(servicesToRun);
            }
            else
            {
                ServiceBase.Run(servicesToRun);
            }
        }

        static void RunInteractive(ServiceBase[] servicesToRun)
        {
            Console.WriteLine("* El servicio esta corriendo en modo interactivo *");
            Console.WriteLine();

            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Iniciando servicio {0}...", service.ServiceName);
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                Console.Write("Iniciado");
            }

            Console.WriteLine();
            Console.WriteLine(
                "Presione una tecla para detener el servicio y el proceso...");
            Console.ReadKey();
            Console.WriteLine();

            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Deteniendo {0}...", service.ServiceName);
                onStopMethod.Invoke(service, null);
                Console.WriteLine("Detenido");
            }

            Console.WriteLine("Todos los servicios planificado estan detenidos.");
            // Permanezco un segundo para que pueda ver el mensaje.
            Thread.Sleep(1000);
        }
    }
}
