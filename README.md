<div align="center">

# 🛡️ MSFamDisable

### *Take Control of Your Windows 11 System*

[![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/Windows-11-0078D6?style=for-the-badge&logo=windows)](https://www.microsoft.com/windows)
[![License](https://img.shields.io/badge/License-GPL%20v3-blue?style=for-the-badge)](LICENSE)

**A powerful utility to disable Windows Family Features by managing system files with administrative precision.**

[Features](#-features) • [Installation](#-installation) • [Usage](#-usage) • [API](#-api-reference) • [Warning](#-warning)

</div>

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 🔐 Force Take Ownership
Takes ownership of protected system files using administrator privileges and PowerShell automation.

</td>
<td width="50%">

### 🗑️ Forced Removal
Removes files and directories with recursive force options—no confirmations needed.

</td>
</tr>
<tr>
<td width="50%">

### ⚡ PowerShell Integration
Seamlessly executes PowerShell commands for system-level operations.

</td>
<td width="50%">

### 🔑 Auto-Elevation
Automatically requests administrator privileges via application manifest.

</td>
</tr>
</table>

---

## 📋 Requirements

```
✓ .NET 9.0 or higher
✓ Windows 11
✓ Administrator privileges
```

### Dependencies

| Package | Version |
|---------|---------|
| `System.Management` | 10.0.0 |
| `System.Management.Automation` | 7.5.4 |

---

## 🚀 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/msfamdisable-win11.git
   ```

2. **Build the project**
   ```bash
   cd msfamdisable-win11
   dotnet build
   ```

3. **Run as Administrator**
   ```bash
   dotnet run
   ```

---

## 💻 Usage

```
MSFamDisable 1.0
by Ari Cummings

Running on user: DOMAIN\Username
This will disable Family Features by removing the executables and libraries
Continue? (Y/N)
```

Simply run the executable with administrator privileges and confirm when prompted.

---

## 📚 API Reference

### `Command` Class

#### `TakeOwn(string path)`
```csharp
// Takes ownership of a protected file
cmd.TakeOwn(@"C:\Windows\System32\example.dll");
```

**Process:**
1. Retrieves current ACL (Access Control List)
2. Creates NTAccount object for current user
3. Sets owner to current user
4. Applies modified ACL to the file

---

#### `Remove(string path)`
```csharp
// Forcefully removes a file or directory
cmd.Remove(@"C:\Program Files\Example\");
```

**Options:**
- ✅ Recursive deletion
- ✅ Force enabled
- ✅ No confirmation prompts

---

#### `Set(string command)` & `Run()`
```csharp
// Execute custom PowerShell commands
cmd.Set("Get-Process | Where-Object {$_.Name -eq 'example'}");
cmd.Run();
```

Programmatically executes PowerShell scripts with output logging.

---

### `RegEdit` Class

#### `DeleteKey(string path)`
```csharp
// Remove registry key and all subkeys
regEdit.DeleteKey(@"HKLM:\SOFTWARE\Microsoft\FamilyStore");
```

#### `CreateValue(string path, string name, string value, string propertyType = "DWORD")`
```csharp
// Create a registry value
regEdit.CreateValue(@"HKLM:\SOFTWARE\Example", "Setting", "1", "DWORD");
```

#### `SetValue(string path, string name, string value)`
```csharp
// Modify existing registry value
regEdit.SetValue(@"HKLM:\SOFTWARE\Example", "Setting", "0");
```

---

### `TaskSchedulerEdit` Class

#### `UnregisterTask(string taskName, string taskPath = "\\")`
```csharp
// Remove a scheduled task
taskScheduler.UnregisterTask("TaskName", @"\Microsoft\Windows\");
```

#### `DisableTask(string taskName, string taskPath = "\\")`
```csharp
// Disable a scheduled task without removing it
taskScheduler.DisableTask("TaskName", @"\Microsoft\Windows\");
```

#### `EnableTask(string taskName, string taskPath = "\\")`
```csharp
// Enable a previously disabled task
taskScheduler.EnableTask("TaskName");
```

---

## 🗑️ What Gets Removed

### Files and Directories
```
C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_x64__8wekyb3d8bbwe\FamilyHub.exe
C:\Program Files\WindowsApps\AppleInc.iCloud_15.5.23.0_x64__nzyj5cx40ttqa\iCloud\WebView2\msedge.dll
C:\Users\[Username]\AppData\Local\Packages\MicrosoftCorporationII.MicrosoftFamily_8wekyb3d8bbwe
C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_x64__8wekyb3d8bbwe
C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_neutral_~_8wekyb3d8bbwe
C:\Program Files\WindowsApps\microsoftcorporationii.microsoftfamily_0.2.40.0_neutral_~_8wekyb3d8bb
```

### Registry Keys
```
HKLM:\SOFTWARE\Microsoft\FamilyStore
HKCU:\Software\Microsoft\FamilyStore
HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\Applications\MicrosoftCorporationII.MicrosoftFamily_*
HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\PackageState\*\MicrosoftCorporationII.MicrosoftFamily_*
HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Notifications\BackgroundCapability\*\Global.FamilyValueProp.*
HKCR:\Extensions\ContractId\Windows.BackgroundTasks\PackageId\MicrosoftCorporationII.MicrosoftFamily_*
HKCR:\Extensions\ContractId\Windows.Launch\PackageId\MicrosoftWindows.Client.Core_*\ActivatableClassId\Global.FamilyValueProp.*
HKCR:\Local Settings\MrtCache\*\MicrosoftCorporationII.MicrosoftFamily_*
HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppContainer\Storage\microsoftcorporationii.microsoftfamily_*
HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Extensions\windows.protocol\ms-family
HKCR:\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages\MicrosoftCorporationII.MicrosoftFamily_*
```

### Scheduled Tasks
```
Task Scheduler Library\Microsoft\Windows\ParentalControls\* (all tasks)
```

---

## ⚠️ Warning

> **This tool modifies protected system files and requires administrator privileges.**
>
> Use with caution and ensure you understand the implications of removing Windows Family Features. Always create a system restore point before running system-modifying tools.

---

## 👤 Author

**Ari Cummings**

---

## 📝 Version

`v1.0` - Initial Release

---

<div align="center">

**Made with ❤️ for system administrators and power users**

</div>
