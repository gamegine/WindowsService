using System.Diagnostics;
using System.ServiceProcess;

namespace WindowsService
{
    public partial class MyService : ServiceBase
    {
        public MyService()
        {
            InitializeComponent();
            eventLog = new EventLog { Source = "MyService" };
        }

        protected override void OnStart(string[] args)=> eventLog.WriteEntry("Start");

        protected override void OnStop() => eventLog.WriteEntry("Stop");
    }
}
