using DiscordRPC;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private static DiscordRpcClient client;
        private CancellationTokenSource _cts;

        private async void Button1_Click(object sender, EventArgs e)
        {
            // Protezione base: evita avvii multipli
            if (client != null && client.IsInitialized)
            {
                MessageBox.Show("RPC già avviata.");
                return;
            }

            string appId = textBox1.Text?.Trim();
            if (string.IsNullOrEmpty(appId))
            {
                MessageBox.Show("Inserisci l'Application ID.");
                return;
            }

            try
            {
                client = new DiscordRpcClient(appId);

                client.OnReady += (s, ea) =>
                {
                    // opzionale: callback quando pronto
                    this.BeginInvoke((Action)(() => MessageBox.Show("Discord RPC connesso.")));
                };

                client.OnError += (s, ea) =>
                {
                    // Log o notifica
                    this.BeginInvoke((Action)(() => MessageBox.Show("Errore RPC: " + ea.Message)));
                };

                client.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore inizializzazione RPC: " + ex.Message);
                client = null;
                return;
            }

            // Imposta la presence
            try
            {
                client.SetPresence(new RichPresence()
                {
                    Details = textBox4.Text,
                    State = textBox2.Text,
                    Assets = new Assets()
                    {
                        LargeImageKey = textBox5.Text,
                        LargeImageText = textBox3.Text,
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore impostando la presenza: " + ex.Message);
                // possiamo decidere di continuare comunque
            }

            // Avvia loop di background che chiama Invoke() regolarmente
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            // Non bloccare la UI — esegui in background
            await Task.Run(() =>
            {
                try
                {
                    while (!token.IsCancellationRequested && client != null && client.IsInitialized)
                    {
                        try
                        {
                            client.Invoke();   // richiama callback/keepalive
                        }
                        catch
                        {
                            // log opcional, non far crashare il thread
                        }
                        Thread.Sleep(1000); // 1s è sufficiente
                    }
                }
                catch (OperationCanceledException) { }
            }, token);

            // Se il Task finisce normalmente, non fa nulla — la pulizia la facciamo altrove
        }

        // Chiudere / pulire quando la form viene chiusa
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            try
            {
                _cts?.Cancel();
            }
            catch { }

            try
            {
                if (client != null)
                {
                    if (client.IsInitialized)
                        client.Deinitialize(); // o Dispose se disponibile
                    client.Dispose();
                    client = null;
                }
            }
            catch { }
        }

        public void Form4_Load(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("----------GUIDA RPC INJECTOR----------\n\n1) Creare un app su https://discord.com/developers/applications\n2) Inserire nella sezione Rich Assets un immagine futura dell' Attività\n3) Copiare ID APPICAZIONE in APPLICATION ID e personalizzare lo Stato.\n4) Inserire in imagename il nome dell'assets publicato sul sito.\n5) Premere su Load Discord RPC e date inizio alla festa!");
        }
    }
}
