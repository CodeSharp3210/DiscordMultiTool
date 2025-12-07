using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        private static readonly string logName = "DiscordMultiTool";
        private static readonly string sourceName = "DiscordMultiTool";

        [STAThread]
        static async Task Main()
        {
            // --- EVENT LOG INIT ---
            InitEventLog();

            WriteEvent("Application started.", EventLogEntryType.Information);

            Console.WriteLine("Loading...");
            await Task.Delay(2000);

            while (true)
            {
                var discordClients = Process.GetProcessesByName("Discord");
                var telegramClients = Process.GetProcessesByName("Telegram");

                bool discordOpen = discordClients.Length > 0;
                bool telegramOpen = telegramClients.Length > 0;

                if (!discordOpen && !telegramOpen)
                {
                    Console.WriteLine("No Discord or Telegram session found.");
                    Console.WriteLine("Press ENTER to retry...");

                    WriteEvent("No Discord or Telegram processes found — operation failed.",
                               EventLogEntryType.Warning);

                    Console.ReadLine();
                    continue;
                }

                // --- PROCESS FOUND EVENTS ---
                if (discordOpen && telegramOpen)
                {
                    WriteEvent("Discord and Telegram processes detected.", EventLogEntryType.Information);

                    Console.WriteLine("Discord and Telegram processes found:");

                    foreach (Process d in discordClients)
                        Console.WriteLine($"Discord | Name: {d.ProcessName} | PID: {d.Id}");

                    foreach (Process t in telegramClients)
                        Console.WriteLine($"Telegram  | Name: {t.ProcessName} | PID: {t.Id}");
                    Console.WriteLine("Press ENTER to continue...");
                    break;
                }
                else if (discordOpen)
                {
                    WriteEvent("Discord process detected.", EventLogEntryType.Information);

                    Console.WriteLine("Discord process found:");
                    foreach (Process d in discordClients)
                        Console.WriteLine($"Name: {d.ProcessName} | PID: {d.Id}");
                    Console.WriteLine("Press ENTER to continue...");
                    break;
                }
                else if (telegramOpen)
                {
                    WriteEvent("Telegram process detected.", EventLogEntryType.Information);

                    Console.WriteLine("Telegram process found:");
                    foreach (Process t in telegramClients)
                        Console.WriteLine($"Name: {t.ProcessName} | PID: {t.Id}");
                    Console.WriteLine("Press ENTER to continue...");
                    break;
                }
           
            }
                // --- DOWNLOAD GUI IMAGE ---
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".dmt");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string filePath = Path.Combine(folder, "GUI.png");

                //URL IMMAGINE
                string url = "https://github.com/CodeSharp3210/DiscordMultiTool/releases/download/DMT-2.5.6/GUI.png"; 
                string url2 = "https://github.com/CodeSharp3210/DiscordMultiTool/releases/download/DMT-2.5.6/Overlay.py";

                try
                {
                    using HttpClient client = new HttpClient();
                    byte[] data = await client.GetByteArrayAsync(url);
                    await File.WriteAllBytesAsync(filePath, data);
                    using HttpClient client2 = new HttpClient();
                    byte[] data2 = await client2.GetByteArrayAsync(url2);
                    string overlayPath = Path.Combine(folder, "Overlay.py");
                    await File.WriteAllBytesAsync(overlayPath, data2);
                }
                catch { }

                string logFile = Path.Combine(folder, "log.txt");
                if (!File.Exists(logFile))
                    File.WriteAllText(logFile, $"DiscordMultiTool injected. {DateTime.Now}");

                WriteEvent("User started the UI stage.", EventLogEntryType.Information);

                Console.ReadLine();

                FreeConsole();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            return;
        }
    
        private static void InitEventLog()
        {
            try
            {
                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, logName);
            }
            catch { }
        }

        private static void WriteEvent(string message, EventLogEntryType type)
        {
            try
            {
                using (EventLog eventLog = new EventLog(logName))
                {
                    eventLog.Source = sourceName;
                    eventLog.WriteEntry(message, type);
                }
            }
            catch { }
        }
    }
}
