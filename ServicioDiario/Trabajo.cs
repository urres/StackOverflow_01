using System;
using Quartz;

namespace ServicioDiario
{
    /*
     * Libreria recomendada para planificacion
     * https://www.quartz-scheduler.net/
     */
    public class Trabajo : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Realizar la tarea planificada.
            System.Console.WriteLine("Hora: " + DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
