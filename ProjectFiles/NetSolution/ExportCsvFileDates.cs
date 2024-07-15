#region Using directives
using System;
using FTOptix.HMIProject;
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

public class ExportCsvFileDates : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Project.Current.GetVariable("NetLogic/DataLoggerExporter/From").Value = DateTime.Now.AddDays(-1);
        Project.Current.GetVariable("NetLogic/DataLoggerExporter/To").Value = DateTime.Now;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
