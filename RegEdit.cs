using System.Management.Automation;

namespace msfamdisable_win11;

public class RegEdit
{
    private Command cmd = new Command();

    public void CreateKey(string path, string keyName)
    {
        cmd.Set($"Get-Item -Path '{path}' | New-Item -Name '{keyName}' -Force");
        Console.WriteLine($"Creating registry key: {path}\\{keyName}");
        cmd.Run();
    }

    public void CreateValue(string path, string name, string value, string propertyType = "DWORD")
    {
        cmd.Set($"New-ItemProperty -Path '{path}' -Name '{name}' -Value \"{value}\" -PropertyType {propertyType} -Force");
        Console.WriteLine($"Creating registry value: {path}\\{name} = {value}");
        cmd.Run();
    }

    public void SetValue(string path, string name, string value)
    {
        cmd.Set($"Set-ItemProperty -Path '{path}' -Name '{name}' -Value \"{value}\"");
        Console.WriteLine($"Setting registry value: {path}\\{name} = {value}");
        cmd.Run();
    }

    public void DeleteKey(string path)
    {
        cmd.Set($"Remove-Item -Path '{path}' -Recurse -Force -Confirm:$false");
        Console.WriteLine($"Deleting registry key: {path}");
        cmd.Run();
    }

    public void DeleteValue(string path, string name)
    {
        cmd.Set($"Remove-ItemProperty -Path '{path}' -Name '{name}' -Force -Confirm:$false");
        Console.WriteLine($"Deleting registry value: {path}\\{name}");
        cmd.Run();
    }
}