using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a DLL";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    [DllImport("kernel32.dll")]
                    static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

                    [DllImport("kernel32.dll")]
                    static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr GetModuleHandle(string lpModuleName);

                    string dllPath = openFileDialog.FileName;
                    Process targetProcess = Process.GetProcessesByName("Discord")[0];

                    IntPtr hProcess = OpenProcess(0x001F0FFF, false, targetProcess.Id);
                    IntPtr addr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllPath.Length + 1, 0x1000 | 0x2000, 0x40);
                    WriteProcessMemory(hProcess, addr, System.Text.Encoding.Default.GetBytes(dllPath), (uint)dllPath.Length + 1, out _);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, addr, 0, out _);

                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
