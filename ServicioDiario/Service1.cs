using System.ServiceProcess;

namespace ServicioDiario
{
    /*
     * Codigo fuente basado en el siguiente enlace en ingles: http://www.codingdefined.com/2016/08/schedule-tasks-as-windows-service-using.html
     */
    public partial class Service1 : ServiceBase
    {
        Planificador plan;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            plan = new Planificador();
            plan.Iniciar();
        }

        protected override void OnStop()
        {
            if (plan != null)
            {
                plan.Detener();
            }
        }
    }
}
