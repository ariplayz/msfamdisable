namespace msfamdisable_win11;

public class TaskSchedulerEdit
{
    private Command cmd = new Command();

    public void UnregisterTask(string taskName, string taskPath = "\\")
    {
        cmd.Set($"Unregister-ScheduledTask -TaskName '{taskName}' -TaskPath '{taskPath}' -Confirm:$false");
        Console.WriteLine($"Unregistering scheduled task: {taskPath}{taskName}");
        cmd.Run();
    }

    public void DisableTask(string taskName, string taskPath = "\\")
    {
        cmd.Set($"Disable-ScheduledTask -TaskName '{taskName}' -TaskPath '{taskPath}'");
        Console.WriteLine($"Disabling scheduled task: {taskPath}{taskName}");
        cmd.Run();
    }

    public void EnableTask(string taskName, string taskPath = "\\")
    {
        cmd.Set($"Enable-ScheduledTask -TaskName '{taskName}' -TaskPath '{taskPath}'");
        Console.WriteLine($"Enabling scheduled task: {taskPath}{taskName}");
        cmd.Run();
    }

    public void GetTask(string taskName)
    {
        cmd.Set($"Get-ScheduledTask -TaskName '{taskName}'");
        Console.WriteLine($"Getting scheduled task: {taskName}");
        cmd.Run();
    }

    public void StartTask(string taskName, string taskPath = "\\")
    {
        cmd.Set($"Start-ScheduledTask -TaskName '{taskName}' -TaskPath '{taskPath}'");
        Console.WriteLine($"Starting scheduled task: {taskPath}{taskName}");
        cmd.Run();
    }

    public void StopTask(string taskName, string taskPath = "\\")
    {
        cmd.Set($"Stop-ScheduledTask -TaskName '{taskName}' -TaskPath '{taskPath}'");
        Console.WriteLine($"Stopping scheduled task: {taskPath}{taskName}");
        cmd.Run();
    }
}