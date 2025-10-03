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

                if (discordClients.Length == 0)
                {
                    Console.WriteLine("No Discord session found...");
                    Console.WriteLine("Press ENTER to retry...");
                    Console.ReadLine();  // aspetta input e ripete
                    continue;
                }

                foreach (Process discord in discordClients)
                {
                    Console.WriteLine("Process found:");
                    Console.WriteLine($"Process Name: Discord.exe | PID: {discord.Id}");
                    Console.WriteLine("Press ENTER to continue with the selected Discord client...");
                    Console.ReadLine();

                    // Chiudi la console
                    FreeConsole();

                    // Avvia la UI
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());

                    return; // esce dal metodo Main
                }
            }
        }
    }
}