#region Using directives
using System;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using UAManagedCore;
using FTOptix.CommunicationDriver;
using FTOptix.RAEtherNetIP;
using FTOptix.UI;
using FTOptix.SerialPort;
using FTOptix.System;
using FTOptix.WebUI;
#endregion

public class ReportEditorOutputMessageLogic : BaseNetLogic
{
    public override void Start()
    {
        messageVariable = Owner.Children.Get<IUAVariable>("Message");
        if (messageVariable == null)
            throw new ArgumentNullException("Unable to find variable Message in OutputMessage label");
    }

    public override void Stop()
    {
        lock (lockObject)
        {
            task?.Dispose();
        }
    }

    [ExportMethod]
    public void SetOutputMessage(string message)
    {
        lock (lockObject)
        {
            task?.Dispose();

            messageVariable.Value = message;
            task = new DelayedTask(() => { messageVariable.Value = ""; }, 5000, LogicObject);
            task.Start();
        }
    }

    [ExportMethod]
    public void SetOutputLocalizedMessage(LocalizedText message) => SetOutputMessage(InformationModel.LookupTranslation(message).Text);

    private DelayedTask task;
    private IUAVariable messageVariable;
    private readonly object lockObject = new object();
}
