using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.IO.Compression;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.DirectoryServices;
using System.Windows.Forms;
namespace ARCHBLOXLauncher1
{
    public partial class Form2 : Form
    {
        public bool Uri_Installed = false;
        public bool IsCompleted = false;
        public bool DontEvenBother = false;
        private static WebClient wc = new WebClient();
        private static ManualResetEvent handle = new ManualResetEvent(true);

        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length) / 1000000;
        }

        public Form2()
        {
            InitializeComponent();
            byte[] raw = wc.DownloadData("https://archblox.com/client/version.txt");
            string webData = Encoding.UTF8.GetString(raw);
            string version_string = webData;
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Archblx\", @"Versions\");
            string clientPath = Path.Combine(folderPath, version_string + @"\");
            string filePath = Path.Combine(clientPath, Path.GetFileName(@"https://archblox.com/client/" + version_string + ".zip"));
            {
                if (Directory.Exists(folderPath))
                {
                    DialogResult res = MessageBox.Show("Do you want to delete previous installs of ARCHBLOX? Current size of ARCHBLOX folder: " + GetDirectorySize(folderPath) + "MB.", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        ARCHBLOXProtocol.ARCHBLOXURIProtocol.Unregister();
                        label1.Text = "Removing previous installs...";
                        Directory.Delete(folderPath, true);

                    }
                }
            }
            wc.DownloadProgressChanged += Client_DownloadProgressChanged;
            wc.DownloadFileCompleted += Client_DownloadFileCompleted;
            progressBar1.Style = ProgressBarStyle.Marquee;
            label1.Text = "Configuring ARCHBLOX...";
            wc.DownloadProgressChanged += Client_DownloadProgressChanged;
            wc.DownloadFileCompleted += Client_DownloadFileCompleted;
            if (Directory.Exists(clientPath))
            {
                DialogResult res = MessageBox.Show("The latest version of ARCHBLOX is already installed. Do you want to re-install it?", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    label1.Text = "Removing previous install...";
                    Directory.Delete(clientPath, true);

                }
                if (res == DialogResult.No)
                {
                    label1.Text = "Cancelled install.";
                    DontEvenBother = true;
                }
            }
            if (DontEvenBother == false)
            {
                Directory.CreateDirectory(clientPath);
                wc.DownloadFileAsync(new Uri(@"https://archblox.com/client/" + version_string + ".zip"), filePath);
                progressBar1.Style = ProgressBarStyle.Blocks;
                handle.WaitOne();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // nothing
        }
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (IsCompleted == false)
            {

                IsCompleted = true;
                byte[] raw = wc.DownloadData("https://archblox.com/client/version.txt");
                string webData = Encoding.UTF8.GetString(raw);
                string version_string = webData;
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Archblx\", @"Versions\");
                string clientPath = Path.Combine(folderPath, version_string + @"\");
                string filePath = Path.Combine(clientPath, Path.GetFileName(@"https://archblox.com/client/" + version_string + ".zip"));
                ZipFile.ExtractToDirectory(filePath, clientPath);
                File.Delete(filePath);
                label1.Text = "Installing URi...";
                try
                {   
                    System.AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
                    ARCHBLOXProtocol.ARCHBLOXURIProtocol.Register();
                    Uri_Installed = true;
                }
                catch { Uri_Installed = false; }
                if (Uri_Installed == true)
                {
                    label1.Text = "ARCHBLOX has been installed!";
                } else
                {
                    label1.Text = "ARCHBLOX installed without URI.";
                }
                
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Minimum = 0;
            double receive = double.Parse(e.BytesReceived.ToString());
            double total = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = receive / total * 100;
            label1.Text = "Installing ARCHBLOX... (" + Math.Truncate(percentage).ToString() + "% Completed)";
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
    }
}
