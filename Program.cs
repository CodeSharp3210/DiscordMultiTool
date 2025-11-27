using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
                }
                else if (discordOpen)
                {
                    WriteEvent("Discord process detected.", EventLogEntryType.Information);

                    Console.WriteLine("Discord process found:");
                    foreach (Process d in discordClients)
                        Console.WriteLine($"Name: {d.ProcessName} | PID: {d.Id}");
                }
                else if (telegramOpen)
                {
                    WriteEvent("Telegram process detected.", EventLogEntryType.Information);

                    Console.WriteLine("Telegram process found:");
                    foreach (Process t in telegramClients)
                        Console.WriteLine($"Name: {t.ProcessName} | PID: {t.Id}");

                    string folder = @"C:\Users\" + Environment.UserName + @"\.dmt";
                    string fileContent = $"DiscordMultiTool injected. " + DateTime.Now;

                    if (Directory.Exists(folder))
                    {
                        if (!File.Exists(folder + @"\log.txt"))
                            File.WriteAllText(folder + @"\log.txt", fileContent);
                    }
                    else
                    {
                        Directory.CreateDirectory(folder);
                    }
                }

                // --- UI START EVENT ---
                WriteEvent("User started the UI stage.", EventLogEntryType.Information);

                Console.WriteLine("\nPress ENTER to run program...");
                Console.ReadLine();

                FreeConsole();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

                return;
            }
        }

        // ============================================================
        //  EVENT VIEWER: INITIALIZATION + WRITE EVENT
        // ============================================================

        private static void InitEventLog()
        {
            try
            {
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, logName);
                }
            }
            catch (Exception ex)
            {
                
            }
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
            catch (Exception ex)
            {

            }
        }
    }
}
