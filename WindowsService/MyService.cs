using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Configuration;

namespace WindowsService
{
    public partial class MyService : ServiceBase
    {
        private int eventId = 1;

        public MyService()
        {
            InitializeComponent();
            eventLog = new EventLog { Source = "MyService" };
        }

        protected override void OnStart(string[] args)
        {
            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 2000; // 2 seconds
            timer.Elapsed += new ElapsedEventHandler(this.RunOnTimer);
            timer.Start();
        }

        protected override void OnStop() => eventLog.WriteEntry("Stop");

        public void RunOnTimer(object sender, ElapsedEventArgs args)
        {
            ConfigurationManager.RefreshSection("appSettings");
            eventLog.WriteEntry("Run On Timer, config test val = " + ConfigurationManager.AppSettings["test"], EventLogEntryType.Information, eventId++);
        }
    }
}
