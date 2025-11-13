using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        [STAThread]
        static async Task Main()
        {
            Console.WriteLine("Loading...");
            await Task.Delay(2000); // puoi ridurre il delay se vuoi

            

            while (true)
            {
                var discordClients = Process.GetProcessesByName("Discord");
                var telegramClients = Process.GetProcessesByName("Telegram");

                bool discordOpen = discordClients.Length > 0;
                bool telegramOpen = telegramClients.Length > 0;

                if (!discordOpen && !telegramOpen)
                {
                    Console.WriteLine("No Discord or Telegram Session found.");
                    Console.WriteLine("Press ENTER to retry...");
                    Console.ReadLine();
                    continue;
                }

                // Messaggio principale con dettagli
                if (discordOpen && telegramOpen)
                {
                    Console.WriteLine("Discord and Telegram Processes found:");
                    foreach (Process d in discordClients)
                        Console.WriteLine($"Discord | Name: {d.ProcessName} | PID: {d.Id}");
                    foreach (Process t in telegramClients)
                        Console.WriteLine($"Telegram | Name: {t.ProcessName} | PID: {t.Id}");
                }
                else if (discordOpen)
                {
                    Console.WriteLine("Discord Process found:");
                    foreach (Process d in discordClients)
                        Console.WriteLine($"Name: {d.ProcessName} | PID: {d.Id}");
                }
                else if (telegramOpen)
                {
                    Console.WriteLine("Telegram Process found:");
                    foreach (Process t in telegramClients)
                        Console.WriteLine($"Name: {t.ProcessName} | PID: {t.Id}");
                }

                Console.WriteLine("\nPress ENTER to run program...");
                Console.ReadLine();

                // Chiudi la console
                FreeConsole();

                    // Avvia la UI
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());

                    return;
                }
            }
        }
    }