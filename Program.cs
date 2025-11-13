using System.Diagnostics;

namespace msfamdisable_win11;

class Program
{
    public static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    static int Main(string[] args)
    {
        
        Console.WriteLine("MSFamDisable 1.0");
        Console.WriteLine("by Ari Cummings");
        Console.WriteLine("");
        Console.WriteLine($"Running on user: {userName}");
        Console.WriteLine("This will disable Family Features by removing the executables and libraries");
        Console.WriteLine("Continue? (Y/N)");
        string gostring = Console.ReadLine();
        if (gostring.ToLower() != "y")
        {
            Console.WriteLine("Exiting...");
            return 1;
        }

        Dictionary<int, string> paths = new Dictionary<int, string>();
        paths.Add(1, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_x64__8wekyb3d8bbwe\FamilyHub.exe");
        paths.Add(2, @"C:\Program Files\WindowsApps\AppleInc.iCloud_15.5.23.0_x64__nzyj5cx40ttqa\iCloud\WebView2\msedge.dll");
        paths.Add(3, @"C:\Users\" + userName + @"\AppData\Local\Packages\MicrosoftCorporationII.MicrosoftFamily_8wekyb3d8bbwe");
        paths.Add(4, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_x64__8wekyb3d8bbwe");
        paths.Add(5, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_neutral_~_8wekyb3d8bbwe");
        paths.Add(6, @"C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_neutral_~_8wekyb3d8bb");
        
        //Get-ChildItem -Path "C:\YourDirectory" -Filter "*report*" to search with powershell
        
        return 0;
    }
}