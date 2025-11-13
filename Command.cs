using System.Diagnostics;
using System.Management.Automation;

namespace msfamdisable_win11;
public class Command
{ 
    private PowerShell cmd = PowerShell.Create();
    private Process proc = new Process();
    
    public void Set(string command)
    {
        Console.WriteLine("");
        Console.WriteLine("Setting command: " + command);
        Console.WriteLine("");
        cmd.AddScript(command);
    }

    public void Run()
    {
        Console.WriteLine("");
        Console.WriteLine("Running command... " + cmd);
        Console.WriteLine("");
        var results = cmd.Invoke();

        // Display results
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
        
        cmd.AddScript("");

    }

    public void RunProcess(string process) 
    {
        Console.WriteLine("");
        Console.WriteLine("Running process: " + process);
        Console.WriteLine("");
        proc.StartInfo.FileName = process;
        proc.Start();
    }

    public void Remove(string path)
    {
        Set("Remove-Item " + path + " -Recurse -Force -Confirm:$false");
        Console.WriteLine("");
        Console.WriteLine("Removing Item: " + path);
        Console.WriteLine("");
        Run();
    }

    public void TakeOwn(string path)
    {
        Set($"$ACL = Get-ACL '{path}'");
        Run();

        Set("$Group = New-Object System.Security.Principal.NTAccount('Builtin', 'Administrators')");
        Run();

        Set("$ACL.SetOwner($Group)");
        Run();

        Set($"Set-Acl -Path '{path}' -AclObject $ACL");
        Console.WriteLine("");
        Console.WriteLine("Taking ownership of: " + path);
        Console.WriteLine("");
        Run();
    }

}