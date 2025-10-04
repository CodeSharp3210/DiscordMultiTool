# Overview

DiscordMultiTool is a Discord automation and experimentation tool developed by MasterSharp Team LLC. The project provides various utilities for working with Discord, with planned expansion to Telegram in the future.

**Important**: This is a Windows Forms .NET application that requires Windows to run. It cannot be executed on Linux/Replit due to platform-specific dependencies (Windows Forms GUI framework and Windows API calls).

# Recent Changes (October 2025)

## UI Modernization
Completely redesigned the application with a modern, single-window interface:

### Navigation System
- **Single-Window Design**: Replaced multiple popup windows with panel-based navigation
- **Left Sidebar**: Modern dark-themed navigation panel with all tools accessible from one place
- **Content Area**: Dynamic panel switching with smooth fade transitions
- **Settings Button**: Added dedicated settings button in navigation panel for easy access

### Panel Structure
1. **Settings Panel**: Application configuration, theme selection, language switcher
2. **Rich Presence Panel**: Discord Rich Presence configuration
3. **Bot Panel**: Python Discord bot loader
4. **DLL Panel**: DLL injection tool

### Multi-Language Support
- **English**: Full translation
- **Italian**: Complete Italian translation (Italiano)
- **Language Switcher**: ComboBox in settings menu for easy language switching
- **Dynamic Updates**: All UI elements update immediately when language changes

### Modern UI Design
- **Color Scheme**: Modern Discord-inspired dark theme
  - Sidebar: #202225 (dark gray)
  - Content: #2F3136 (medium gray)
  - Accents: #7289DA (Discord blue)
- **Flat Design**: Modern flat buttons with hover effects
- **Typography**: Clean Segoe UI font throughout
- **Spacing**: Improved padding and margins for better visual hierarchy

### Animations & Interactions
- **Smooth Transitions**: Fade in/out effects when switching panels
- **Animated Highlight**: Blue highlight panel that smoothly slides to selected sidebar button
- **Rounded Buttons**: All buttons feature 10-15px border radius for modern appearance
- **Color-Coded Actions**: Danger actions (red) for destructive operations
- **Visual Feedback**: Clear visual states for all interactive elements
- **Theme-Aware Colors**: Text automatically changes to black for Modern/light theme, white for Classic/dark theme

### Removed Elements
- Removed ugly "Settings" overlay label that cluttered the header
- Eliminated separate popup windows (Form2, Form3, Form4)
- Cleaned up old TabControl-based navigation

# User Preferences

- Preferred communication style: Simple, everyday language
- Language: English and Italian support

# Technical Architecture

## Platform Architecture
- **Primary Platform**: Windows (.NET 8.0 with Windows Forms)
- **GUI Framework**: Windows Forms (Windows-only)
- **Windows APIs**: Uses kernel32.dll and User32.dll for DLL injection
- **Replit Compatibility**: Cannot run on Linux due to Windows Forms and Windows API dependencies

## Core Components

### Form1 - Main Application Window
- Single-window navigation system
- Panel-based content switching
- Multi-language dictionary system
- Theme management (Modern/Classic)
- Integrated all functionality from separate forms

### Discord Features
1. **Rich Presence (formerly Form4)**: Custom Discord status with RPC
2. **Bot Loader (formerly Form3)**: Python Discord bot launcher with dependency checking
3. **DLL Injection (formerly Form2)**: Windows-specific DLL injection into Discord process
4. **Connection Status**: Check Discord process connection
5. **Developer Portal**: Quick access to Discord Developer Portal

### Settings & Configuration
- **Auto-save**: Optional automatic settings persistence
- **Discord Account**: Account configuration
- **Target Server**: Server targeting options
- **Theme Switcher**: Modern/Classic theme toggle
- **Color Customization**: GUI color picker
- **Language Selection**: English/Italian switcher
- **Discord Patch**: Explorer restart functionality

## Dependencies

### NuGet Packages
- **DiscordRichPresence** (v1.6.1.70): Discord RPC integration

### .NET Version
- **.NET 8.0**: Target framework with Windows Forms support
- **Windows 10.0.26100.0**: Minimum supported Windows version

### Platform-Specific
- **Windows Forms**: GUI framework (Windows-only)
- **Windows API**: DLL injection capabilities via P/Invoke
  - kernel32.dll: Process manipulation
  - User32.dll: Window management

## Future Plans

### Telegram Integration
- Premium Telegram features in development
- Similar architecture to Discord implementation

### Cross-Platform Considerations
- Linux version planned but without Windows-specific features
- DLL injection will be excluded from non-Windows builds
- GUI framework would need to be replaced for Linux compatibility

# File Structure

```
DiscordMultiTool/
├── Form1.cs                 # Main window with all integrated functionality
├── Form1.Designer.cs        # UI designer code with modern layout
├── Form2.cs                 # (Legacy - DLL injection, now in Form1)
├── Form3.cs                 # (Legacy - Bot loader, now in Form1)
├── Form4.cs                 # (Legacy - RPC, now in Form1)
├── Program.cs               # Entry point with Discord process detection
├── DiscordMultiTool.csproj  # Project configuration
├── DiscordMultiTool.sln     # Solution file
├── Logo.ico                 # Application icon
└── README.md                # Project documentation
```

# Development Notes

## Why This Won't Run on Replit
1. **Windows Forms**: Linux doesn't support the Windows Forms GUI framework
2. **Windows API Calls**: DllImport of kernel32.dll and User32.dll are Windows-specific
3. **Platform Detection**: Code checks for Windows processes (Discord.exe, explorer.exe)
4. **Native Interop**: P/Invoke calls require Windows platform

## To Run This Application
- **Windows Required**: Must be run on Windows OS
- **Visual Studio**: Recommended IDE for development
- **.NET 8.0 SDK**: Install from Microsoft
- **Discord**: Discord client must be running for some features

## Design Decisions

### Why Single-Window Navigation?
- **Better UX**: No cluttered popup windows
- **Modern Feel**: Follows current UI/UX trends
- **Easier Navigation**: All features accessible from sidebar
- **Visual Consistency**: Unified design language throughout

### Why Multi-Language?
- **International Audience**: Italian translation for broader reach
- **Extensibility**: Easy to add more languages
- **User Preference**: Users can choose their preferred language

### Why Panel-Based Architecture?
- **Performance**: Panels are lightweight and fast
- **Smooth Transitions**: Easy to add animations between views
- **Maintainability**: Each feature isolated in its own panel
- **Scalability**: Easy to add new features as panels
