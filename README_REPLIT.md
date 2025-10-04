# DiscordMultiTool - Replit Notes

## ⚠️ Important: Windows-Only Application

This is a **Windows Forms .NET 8.0 application** that **cannot run on Linux/Replit**.

### Why It Can't Run on Replit:
1. **Windows Forms**: The GUI framework is Windows-specific
2. **Windows APIs**: Uses `kernel32.dll` and `User32.dll` via P/Invoke
3. **Platform Dependencies**: Requires Windows OS to execute

### What Was Modernized:
✅ **Complete UI Redesign** - Modern single-window interface
✅ **Panel Navigation** - No more popup windows
✅ **Multi-Language** - English & Italian support
✅ **Smooth Animations** - Fade transitions & hover effects
✅ **Modern Theme** - Discord-inspired dark design

### To Use This Application:
1. Clone this repository to a **Windows machine**
2. Install **.NET 8.0 SDK**
3. Open in **Visual Studio** or **Rider**
4. Build and run on Windows

### Development on Windows:
```bash
dotnet restore
dotnet build
dotnet run
```

---

**Note**: The code has been fully modernized with improved UX, translations, and animations, but must be run on Windows to function.
