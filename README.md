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
2. Creates `Builtin\Administrators` NTAccount object
3. Sets owner to Administrators group
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
