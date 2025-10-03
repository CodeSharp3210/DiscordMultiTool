open System
open System.Diagnostics
open System.Runtime.InteropServices
open System.Threading.Tasks
open System.Windows.Forms

module Program =

    [<DllImport("kernel32.dll")>]
    extern bool FreeConsole()

    [<STAThread>]
    [<EntryPoint>]
    let main argv =
        let task = task {
            Console.WriteLine("Loading...")
            do! Task.Delay(2000) // puoi ridurre il delay se vuoi

            let mutable keepRunning = true

            while keepRunning do
                let discordClients = Process.GetProcessesByName("Discord")

                if discordClients.Length = 0 then
                    Console.WriteLine("No Discord session found...")
                    Console.WriteLine("Press ENTER to retry...")
                    Console.ReadLine() |> ignore
                else
                    for discord in discordClients do
                        Console.WriteLine("Process found:")
                        Console.WriteLine($"Process Name: Discord.exe | PID: {discord.Id}")
                        Console.WriteLine("Press ENTER to continue with the selected Discord client...")
                        Console.ReadLine() |> ignore

                        // Chiudi la console
                        FreeConsole() |> ignore

                        // Avvia la UI
                        Application.EnableVisualStyles()
                        Application.SetCompatibleTextRenderingDefault(false)
                        Application.Run(new Form1())

                        keepRunning <- false
        }
        task.Wait()
        0
