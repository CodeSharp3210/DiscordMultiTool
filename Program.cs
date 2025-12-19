using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordMultiTool;

internal class Program
{
    private static readonly string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DiscordMultiTool");
    private static readonly string logFile = Path.Combine(folder, "log.txt");
    private static CancellationTokenSource cts = new();

    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            WriteLog("Application started.");

            // Avvia task in background
            Task.Run(() => MonitorProcessesAsync(cts.Token));

            // Scarica GUI e overlay
            Task.Run(() => DownloadFilesAsync());

            // Avvia Avalonia UI
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

            // Quando chiude la UI
            cts.Cancel();
            WriteLog("Application closed.");
        }
        catch (Exception ex)
        {
            WriteLog("Error: " + ex.ToString());
            Console.WriteLine("An error occurred: " + ex.Message);
            Console.ReadKey();
        }
    }

    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();

    private static async Task MonitorProcessesAsync(CancellationToken token)
    {
        WriteLog("Starting process monitoring...");

        while (!token.IsCancellationRequested)
        {
            var discord = Process.GetProcessesByName("Discord");
            var telegram = Process.GetProcessesByName("Telegram");

            if (discord.Length == 0 && telegram.Length == 0)
            {
                WriteLog("No Discord or Telegram processes found.");
            }

            if (discord.Length > 0 && telegram.Length > 0)
            {
                WriteLog("Discord and Telegram processes detected.");
            }
            else if (discord.Length > 0)
            {
                WriteLog("Discord process detected.");
            }
            else if (telegram.Length > 0)
            {
                WriteLog("Telegram process detected.");
            }

            await Task.Delay(3000, token); // Controlla ogni 3 secondi
        }
    }

    private static async Task DownloadFilesAsync()
    {
        try
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string guiPath = Path.Combine(folder, "GUI.png");
            string overlayPath = Path.Combine(folder, "Overlay.py");

            string urlGui = "https://github.com/CodeSharp3210/DiscordMultiTool/releases/download/DMT-2.5.6/GUI.png";
            string urlOverlay = "https://github.com/CodeSharp3210/DiscordMultiTool/releases/download/DMT-2.5.6/Overlay.py";

            using HttpClient client = new();
            byte[] guiData = await client.GetByteArrayAsync(urlGui);
            await File.WriteAllBytesAsync(guiPath, guiData);
            WriteLog("GUI.png downloaded.");

            byte[] overlayData = await client.GetByteArrayAsync(urlOverlay);
            await File.WriteAllBytesAsync(overlayPath, overlayData);
            WriteLog("Overlay.py downloaded.");

            // Log iniziale se non esiste
            if (!File.Exists(logFile))
                await File.WriteAllTextAsync(logFile, $"DiscordMultiTool initialized at {DateTime.Now}\n");

        }
        catch (Exception ex)
        {
            WriteLog("Error downloading files: " + ex.ToString());
        }
    }

    private static void WriteLog(string message)
    {
        try
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n";
            File.AppendAllText(logFile, logEntry);
        }
        catch
        {
            // Ignora errori di scrittura
        }
    }
}
