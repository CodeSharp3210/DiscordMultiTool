# DiscordMultiTool - Project Information

## Overview
DiscordMultiTool is a Windows Forms desktop application created by MasterSharp Team LLC and Franciplay58 for Discord automation, customization, and experimentation.

## Recent Changes
- **2025-10-16**: MAJOR FIX - Completely resolved Form5 and button corner issues (Windows version)
  - **Form5 Telegram Features**: Replaced with full working version including Python bot loader, Telegram message sender, and settings persistence
  - **Form5 Designer**: Created proper layout with scrollable container panel, properly positioned controls, and correct sizing for embedded display
  - **Button Corners**: Completely rewrote button rendering using owner-drawn approach with FlatStyle.Flat
  - **Smooth Rendering**: Now uses SmoothingMode.AntiAlias with rounded pen caps/joins for silky-smooth corners (no more blocky/jaggy edges!)
  - **Custom Paint Handler**: Draws background first with FillPath, then border with anti-aliased rendering, then centered text
  - All buttons now render with professional, smooth rounded corners across both Modern and Classic themes
- **2025-10-16**: Fixed UI issues across ALL platforms (Windows, Linux web, Linux desktop)
  - **Linux web version**: Increased button border-radius to 8-10px for smoother corners
  - **Linux web version**: Added smooth transitions, hover effects, and active state visual indicators
  - **Linux web version**: Enhanced form controls with better styling and focus states
  - **Linux desktop version**: Increased nav button CornerRadius from 8 to 10
  - **Linux desktop version**: Increased accent button CornerRadius from 6 to 8
  - **Linux desktop version**: Added smooth transitions and hover animations
  - **Linux desktop version**: Applied CornerRadius to TextBox and ComboBox controls
  - All button styling now consistent and polished across all three platforms
- **2025-10-16**: Upgraded ALL projects to .NET 8.0
  - Upgraded Windows version from .NET 7.0 to .NET 8.0 (no more security warnings!)
  - Upgraded web version (DiscordMultiToolLinux) from .NET 7 to .NET 8
  - Upgraded desktop version (DiscordMultiToolDesktop) to .NET 8
  - All projects now on supported .NET framework with security updates
- **2025-10-16**: Fixed cross-thread UI update crash in Linux desktop version
  - Fixed "Call from invalid thread" exception in Avalonia desktop app
  - Wrapped all UI updates in event handlers with Dispatcher.UIThread.Post()
  - Fixed threading issues in App.axaml.cs, SettingsViewModel, DiscordRpcViewModel, and TelegramViewModel
  - Application now handles theme changes, language switches, and button clicks without crashing
- **2025-10-16**: Created Linux-compatible versions
  - Upgraded web version (DiscordMultiToolLinux) from .NET 7 to .NET 8
  - Created native desktop version (DiscordMultiToolDesktop) using Avalonia UI
  - Desktop version features: MVVM architecture, ReactiveUI, full Discord RPC support
  - Desktop version runs on Linux, Windows, and macOS (requires display server)
  - Both versions share similar UI design and feature set
  - Note: Desktop version cannot run on Replit (headless environment)
- **2025-10-16**: Created Linux-compatible web version in LINUX/ folder
  - Built web-based version using ASP.NET Core Blazor Server
  - Implemented Discord Rich Presence (works on Linux)
  - Implemented Telegram features (works on Linux)
  - Implemented Python bot loader interface (works on Linux)
  - Created Discord-style dark theme UI
  - Running on port 5000 with Blazor Server
  - Note: DLL injection not available (Windows-only feature)
- **2025-10-16**: Fixed Telegram Features button UI bug (Windows version)
  - Added missing `AnimateHighlight(300)` call to move the highlight indicator when Telegram button is clicked
  - Replaced manual panel switching with `SwitchPanel(telegramPanel)` for consistent behavior with other navigation buttons
  - Simplified Form5 hosting logic to prevent duplicate controls

## Project Architecture
- **Technology**: .NET Windows Forms application
- **Target Platform**: Windows 10+ (requires Windows-specific APIs)
- **Language**: C#
- **Key Features**:
  - Discord Rich Presence customization
  - Python bot loader
  - DLL injection (Windows only)
  - Discord process management
  - Telegram features (Form5)
  - Multi-language support (English, Italian)
  - Theme system (Modern/Classic)

## Important Limitations

### Platform Compatibility
**This application CANNOT run on Replit's Linux environment** because:
1. **Windows Forms**: Requires Windows OS - not supported on Linux
2. **Windows APIs**: Uses Windows-specific features (kernel32.dll, DLL injection, process manipulation)
3. **Discord Integration**: Requires Discord client running locally on Windows

### Development Environment
- **Local Development**: Requires Windows with Visual Studio or Visual Studio Code
- **Build**: Requires .NET 8.0 SDK
- **Runtime**: Windows 10 or later
- **Framework**: .NET 8.0 (all projects upgraded)

## Project Structure
```
├── Form1.cs/.Designer.cs     - Main application window with sidebar navigation
├── Form2.cs/.Designer.cs     - Rich Presence panel
├── Form3.cs/.Designer.cs     - Bot loader panel  
├── Form4.cs/.Designer.cs     - DLL injection panel
├── Form5.cs/.Designer.cs     - Telegram features panel (NEW)
├── Program.cs                - Entry point, Discord process detection
├── Properties/              - Application settings and resources
└── DiscordMultiTool.csproj  - Project configuration
```

## Navigation System
The application uses a highlight indicator (blue bar) that animates to show the selected sidebar button:
- **Button positions** (Y coordinates for AnimateHighlight):
  - Discord Rich Presence: 20
  - Discord Bot (Python): 76
  - Inject DLL: 132
  - Discord Connection: 188
  - Developer Portal: 244
  - Telegram Features: 300
  - Close Discord: 370
  - Exit Application: 426
  - Settings: 496

## User Preferences
No specific preferences documented yet.

## Contributors
- **Franciplay58** - Main GUI developer and UI/function integration
- **MasterSharp** - Secondary developer, translator, and feature developer
- **itelcan3** - Additional translation

## Repository
https://github.com/CodeSharp3210/DiscordMultiTool
