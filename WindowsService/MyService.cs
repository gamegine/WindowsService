using System.Diagnostics;
using System.ServiceProcess;

namespace WindowsService
{
    public partial class MyService : ServiceBase
    {
        public MyService()
        {
            InitializeComponent();
            eventLog = new EventLog();
            if (!EventLog.SourceExists("MyService"))
                EventLog.CreateEventSource("MyService", "MyLog");
            eventLog.Source = "MyService";
            eventLog.Log = "MyLog";
        }

        protected override void OnStart(string[] args)=> eventLog.WriteEntry("Start");

        protected override void OnStop() => eventLog.WriteEntry("Stop");
    }
}
