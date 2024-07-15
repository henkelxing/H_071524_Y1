#region Using directives
using System;
using FTOptix.NetLogic;
using UAManagedCore;
using FTOptix.Report;
using FTOptix.CommunicationDriver;
using FTOptix.RAEtherNetIP;
using FTOptix.UI;
using FTOptix.SerialPort;
using FTOptix.System;
using FTOptix.WebUI;
#endregion

public class ClockLogic : BaseNetLogic
{
    public override void Start()
    {
        periodicTask = new PeriodicTask(UpdateTime, 1000, LogicObject);
        periodicTask.Start();
    }

    public override void Stop()
    {
        periodicTask.Dispose();
        periodicTask = null;
    }

    private void UpdateTime()
    {
        LogicObject.GetVariable("Time").Value = DateTime.Now;
        LogicObject.GetVariable("UTCTime").Value = DateTime.UtcNow;
    }

    private PeriodicTask periodicTask;
}
