using System.Diagnostics;

namespace msfamdisable_win11;

class Program
{
    public static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    static int Main(string[] args)
    {
        RegEdit regEdit = new RegEdit();
        
        Console.WriteLine("MSFamDisable 1.0");
        Console.WriteLine("by Ari Cummings");
        Console.WriteLine("");
        Console.WriteLine($"Running on user: {userName}");
        Console.WriteLine("This will disable Family Features by removing the executables and libraries");
        Console.WriteLine("Continue? (Y/N)");
        string? gostring = Console.ReadLine();
        if (gostring?.ToLower() != "y")
        {
            Console.WriteLine("Exiting...");
            return 1;
        }

        Dictionary<int, string> DrivePaths = new Dictionary<int, string>();
        DrivePaths.Add(1, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_x64__8wekyb3d8bbwe\FamilyHub.exe");
        DrivePaths.Add(2, @"C:\Program Files\WindowsApps\AppleInc.iCloud_15.5.23.0_x64__nzyj5cx40ttqa\iCloud\WebView2\msedge.dll");
        DrivePaths.Add(3, @"C:\Users\" + userName + @"\AppData\Local\Packages\MicrosoftCorporationII.MicrosoftFamily_8wekyb3d8bbwe");
        DrivePaths.Add(4, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_x64__8wekyb3d8bbwe");
        DrivePaths.Add(5, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_neutral_~_8wekyb3d8bbwe");
        DrivePaths.Add(6, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_neutral_~_8wekyb3d8bb");
        
        //Get-ChildItem -Path "C:\YourDirectory" -Filter "*report*" to search with powershell
        
        Dictionary<int, string> RegPaths = new Dictionary<int, string>();
        RegPaths.Add(1, @"HKLM:\SOFTWARE\Microsoft\FamilyStore");
        RegPaths.Add(2, @"HKCU:\Software\Microsoft\FamilyStore");
        RegPaths.Add(3, @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\Applications\MicrosoftCorporationII.MicrosoftFamily_0.2.40.0_neutral_~_8wekyb3d8bbwe");
        RegPaths.Add(4, @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\S-1-5-21-3128016840-3358702660-2539043694-1001\MicrosoftCorporationII.MicrosoftFamily_0.2.40.0_neutral_~_8wekyb3d8bbwe");
        RegPaths.Add(5, @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\PackageState\S-1-5-21-3128016840-3358702660-2539043694-1001\MicrosoftCorporationII.MicrosoftFamily_8wekyb3d8bbwe");
        RegPaths.Add(6, @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Notifications\BackgroundCapability\S-1-15-2-1865096472-3228082684-3088735348-2044108251-975292724-3239066845-4226050315\Global.FamilyValueProp.AppXdb3s90jwjgkk1f1yvb5bg2a6df5gd74s.mca");
        RegPaths.Add(7, @"HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Notifications\BackgroundCapability\S-1-15-2-1865096472-3228082684-3088735348-2044108251-975292724-3239066845-4226050315\Global.FamilyValueProp.AppXyyjxcd83tmf7bbr17tr4ampwedcc3nm8.wwa");
        RegPaths.Add(8, @"HKCR:\Extensions\ContractId\Windows.BackgroundTasks\PackageId\MicrosoftCorporationII.MicrosoftFamily_0.2.40.0_x64__8wekyb3d8bbwe");
        RegPaths.Add(9, @"HKCR:\Extensions\ContractId\Windows.Launch\PackageId\MicrosoftWindows.Client.Core_1000.26100.81.0_x64__cw5n1h2txyewy\ActivatableClassId\Global.FamilyValueProp.wwa");
        RegPaths.Add(10, @"HKCR:\Local Settings\MrtCache\C:%5CProgram Files%5CWindowsApps%5CMicrosoftCorporationII.MicrosoftFamily_0.2.40.0_x64__8wekyb3d8bbwe%5Cresources.pri");
        RegPaths.Add(11, @"HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppContainer\Storage\microsoftcorporationii.microsoftfamily_8wekyb3d8bbwe");
        RegPaths.Add(12, @"HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Extensions\windows.protocol\ms-family");
        RegPaths.Add(13, @"HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages\MicrosoftCorporationII.MicrosoftFamily_0.2.40.0_neutral_~_8wekyb3d8bbwe");
        RegPaths.Add(14, @"HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages\MicrosoftCorporationII.MicrosoftFamily_0.2.40.0_x64__8wekyb3d8bbwe\MicrosoftCorporationII.MicrosoftFamily_8wekyb3d8bbwe!App");
        RegPaths.Add(15, @"HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages\MicrosoftCorporationII.MicrosoftFamily_0.2.40.0_x64__8wekyb3d8bbwe\MicrosoftCorporationII.MicrosoftFamily_8wekyb3d8bbwe!App\windows.protocol\ms-family");

        Dictionary<int, string> SchedulePaths = new Dictionary<int, string>();
        SchedulePaths.Add(1, @"\Microsoft\Windows\ParentalControls\");

        Command command = new Command();
        TaskSchedulerEdit taskScheduler = new TaskSchedulerEdit();

        // Remove files and directories
        foreach (var path in DrivePaths.Values)
        {
            command.TakeOwn(path);
            command.Remove(path);
        }

        // Remove registry keys
        foreach (var path in RegPaths.Values)
        {
            regEdit.DeleteKey(path);
        }

        // Remove scheduled tasks (requires task name, adding placeholder)
        foreach (var path in SchedulePaths.Values)
        {
            // Note: UnregisterTask needs both path and task name
            // Add specific task names if known, or use Get-ScheduledTask to find them first
            taskScheduler.UnregisterTask("*", path);
        }

        Console.WriteLine("");
        Console.WriteLine("Your computer needs to be restarted for the changes to take effect.");
        Console.WriteLine("Press any key to restart...");
        Console.ReadLine();
        Process.Start("shutdown", "/r /t 0");
        return 0;
    }
}