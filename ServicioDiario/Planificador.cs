using Quartz;
using Quartz.Impl;

namespace ServicioDiario
{
    public class Planificador
    {
        public void Iniciar()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<Trabajo>().Build();
            //Cada 15 segundos
            ITrigger trigger = TriggerBuilder.Create()
                   .WithSimpleSchedule(a => a.WithIntervalInSeconds(15).RepeatForever())
                   .Build();
            
            // Cada un dia
            //ITrigger trigger = TriggerBuilder.Create()
            //       .WithSimpleSchedule(a => a.WithIntervalInHours(24).RepeatForever())
            //       .Build();

            scheduler.ScheduleJob(job, trigger);
        }

        public void Detener()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Shutdown();
        }
    }
}
