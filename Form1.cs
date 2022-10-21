﻿using System;
using System.Text;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using DiscordRPC;
namespace ARCHBLOXLauncherGUI
{
    public partial class Form1 : Form
    {
        private void CreateShortcut()
        {
            // create shortcut on user's desktop
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\ARCHBLOX Launcher.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "ARCHBLOX Player";
            shortcut.TargetPath = ARCHBLOXLauncherGUI.Extensions.GetExecutablePath();
            shortcut.Save();
        }
        // variables
        bool exitafterarg = false;
        bool rbxl = false;
        private DiscordRpcClient client;
        bool ingame = false;
        bool hosting = false;
        private static WebClient wc = new WebClient();
        static byte[] raw = wc.DownloadData("http://archblox.com/client/version.txt");
        static string webData = Encoding.UTF8.GetString(raw);
        static string version_string = webData;
        static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Archblx\", @"Versions\");
        static string clientPath = Path.Combine(folderPath, version_string + @"\");
        static string filePath = Path.Combine(clientPath, "ArchbloxPlayerBeta.exe");
        delegate void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e);
        public Form1()
        {
            InitializeComponent();
            // Check for a internet connection
            try
            {
                wc.DownloadData("http://archblox.com/client/version.txt");
            }
            catch
            {
                MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: HttpOpenRequest failed for GET http://archblox.com/client/version.txt, Error ID: 6", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            ARCHBLOXProtocol.ARCHBLOXURIProtocol.Register();
            CreateShortcut();
            var lastword = "";
            var info1 = "";
            var info2 = "";
            string[] args = ARCHBLOXProtocol.SharedVariables.Arguments.Split('/');
            // check to see if uri/arguments were used
            foreach (var word in args)
            {
                if (lastword == "host")
                {
                    if (!System.IO.File.Exists(filePath))
                    {
                        DialogResult res = MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Out of date client! To update the client select Yes.", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            ARCHBLOXLauncherGUI.Form2 form2 = new ARCHBLOXLauncherGUI.Form2();
                            form2.Show();
                        } else
                        {
                            Environment.Exit(0);
                        }
                    }
                    exitafterarg = true;
                    lastword = "stop";
                    string[] info = word.Split(':');
                    foreach (var word2 in info)
                    {
                        if (info1 == "")
                        {
                            info1 = word2;
                        }
                        else
                        {
                            info2 = word2;
                        }
                    }
                    if (info1 == "" || info2 == "")
                    {
                        MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Invalid Arguments, Error ID: 500", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    var pProcess = new Process();
                    hosting = true;
                    pProcess.StartInfo.FileName = filePath;
                    pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/gameserver.php?port=" + info1 + "&rbxl=" + info2 + "\" -t \"1\"";
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    pProcess.StartInfo.CreateNoWindow = false;
                    pProcess.Start();
                    MessageBox.Show("Starting game server on port " + info1 + " using " + info2, "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (lastword == "join")
                {
                    if (!System.IO.File.Exists(filePath))
                    {
                        DialogResult res = MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Out of date client! To update the client, select Yes.", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            ARCHBLOXLauncherGUI.Form2 form2 = new ARCHBLOXLauncherGUI.Form2();
                            form2.Show();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    exitafterarg = true;
                    lastword = "stop";
                    string[] info = word.Split(':');
                    foreach (var word2 in info)
                    {
                        if (info1 == "")
                        {
                            info1 = word2;
                        }
                        else
                        {
                            info2 = word2;
                        }
                    }
                    if (info1 == "" || info2 == "")
                    {
                        MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Invalid Arguments, Error ID: 500", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    var pProcess = new Process();
                    hosting = true;
                    pProcess.StartInfo.FileName = filePath;
                    pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/join.ashx?port=" + info1 + "&ip=" + info2 + "\" -t \"1\"";
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    pProcess.StartInfo.CreateNoWindow = false;
                    pProcess.Start();
                    MessageBox.Show("Joining " + info2 + ":" + info1, "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (word == "install")
                {
                    ARCHBLOXLauncherGUI.Form2 form2 = new ARCHBLOXLauncherGUI.Form2();
                    form2.Show();
                }
                if (word == "") { }
                else
                {
                    lastword = word;
                }
            }

            if (exitafterarg == true)
            {
                // close program
                Environment.Exit(0);
            }
            client = new DiscordRpcClient("996030605106090006");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Launcher",
                State = "Browsing through the menus...",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "launcher",
                    SmallImageKey = "archblox",
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // hosting
            string phrase = textBox2.Text;
            string[] words = phrase.Split('.');
            string sWord = "";
            foreach (var word in words)
            {
                sWord = word.ToLower();
                if (sWord == "rbxl")
                {
                    rbxl = true;
                }
                else
                {
                    rbxl = false;
                }
            }
            if (!System.IO.File.Exists(filePath))
            {
                DialogResult res =  MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Out of date client! To update the client, select Yes or select the Install button on the main menu.", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res == DialogResult.Yes)
                {
                    ARCHBLOXLauncherGUI.Form2 form2 = new ARCHBLOXLauncherGUI.Form2();
                    form2.Show();
                }
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill in all of the text boxes.", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rbxl == false)
            {
                MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Invalid .RBXL, " + sWord + " is not a supported file format.", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Check if RADMIN VPN ip address to protect port forwarders from exposing their ip address and potentionally causing the server hoster to be doxxed/ddossed
                string phrase2 = serverip.Text;
                string[] words2 = phrase2.Split('.');
                string sWord2 = "";
                bool radmin = false;
                foreach (var word in words2)
                {
                    sWord2 = word.ToLower();
                    if (sWord2 == "26" || sWord2 == "localhost" || sWord2 == "192" || sWord2 == "10" || sWord2 == "127")
                    {
                        radmin = true;
                    }
                    else
                    {
                        radmin = false;
                    }
                    break;
                }
                if (radmin == false)
                {
                    phrase2 = "[IP HIDDEN]"; // HAHAHA DUDE THESE DOXXERS AND DDOSSERS ARE SO FUCKING FUNNY THEY MAKE ME WANT TO MERGE WITHOUT LOOKING!!!! 
                }
                void ProcessExitHandler(object sender, EventArgs args)
                {
                    hosting = false;
                    if (ingame == true)
                    {
                        client.SetPresence(new DiscordRPC.RichPresence()
                        {
                            Details = "Playing a Game",
                            State = "on " + phrase2 + ":" + serverport.Text,
                            Timestamps = Timestamps.Now,
                            Assets = new Assets()
                            {
                                LargeImageKey = "ingame",
                                SmallImageKey = "archblox",
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new DiscordRPC.RichPresence()
                        {
                            Details = "Launcher",
                            State = "Browsing through the menus...",
                            Timestamps = Timestamps.Now,
                            Assets = new Assets()
                            {
                                LargeImageKey = "launcher",
                                SmallImageKey = "archblox",
                            }
                        });
                    }
                }
                var pProcess = new Process();
                hosting = true;
                pProcess.StartInfo.FileName = filePath;
                pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/gameserver.php?port=" + textBox1.Text + "&rbxl=" + textBox2.Text + "\" -t \"1\"";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                pProcess.StartInfo.CreateNoWindow = false;
                pProcess.Start();
                pProcess.EnableRaisingEvents = true;
                pProcess.Exited += new EventHandler(ProcessExitHandler);
                var random = new Random();
                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = "Hosting",
                    State = textBox2.Text,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = "host",
                        SmallImageKey = "archblox",
                    }
                });
                MessageBox.Show("Starting game server on port " + textBox1.Text + " using " + textBox2.Text, "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // joining
            if (!System.IO.File.Exists(filePath))
            {
                DialogResult res = MessageBox.Show("An error occoured while starting ARCHBLOX\n\nDetails: Out of date client! To update the client, select Yes or select the Install button on the main menu.", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res == DialogResult.Yes)
                {
                    ARCHBLOXLauncherGUI.Form2 form2 = new ARCHBLOXLauncherGUI.Form2();
                    form2.Show();
                }
            }
            else if (serverip.Text == "" || serverport.Text == "")
            {
                MessageBox.Show("Please fill in all of the text boxes.", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                void ProcessExitHandler(object sender, EventArgs args)
                {
                    ingame = false;
                    if (hosting == true)
                    {
                        client.SetPresence(new DiscordRPC.RichPresence()
                        {
                            Details = "Hosting",
                            State = textBox2.Text,
                            Timestamps = Timestamps.Now,
                            Assets = new Assets()
                            {
                                LargeImageKey = "host",
                                SmallImageKey = "archblox",
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new DiscordRPC.RichPresence()
                        {
                            Details = "Launcher",
                            State = "Browsing through the menus...",
                            Timestamps = Timestamps.Now,
                            Assets = new Assets()
                            {
                                LargeImageKey = "launcher",
                                SmallImageKey = "archblox",
                            }
                        });
                    }
                }
                var pProcess = new Process();
                ingame = true;
                pProcess.StartInfo.FileName = filePath;
                pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/join.ashx?port=" + serverport.Text + "&ip=" + serverip.Text + "\" -t \"1\"";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                pProcess.StartInfo.CreateNoWindow = false;
                pProcess.Start();
                pProcess.EnableRaisingEvents = true;
                pProcess.Exited += new EventHandler(ProcessExitHandler);

                // Check if RADMIN VPN ip address to protect port forwarders from exposing their ip address and potentionally causing the server hoster to be doxxed/ddossed
                string phrase2 = serverip.Text;
                string[] words2 = phrase2.Split('.');
                string sWord2 = "";
                bool radmin = false;
                foreach (var word in words2)
                {
                    sWord2 = word.ToLower();
                    if (sWord2 == "26" || sWord2 == "localhost" || sWord2 == "192" || sWord2 == "10" || sWord2 == "127")
                    {
                        radmin = true;
                    }
                    else
                    {
                        radmin = false;
                    }
                    break;
                }
                if (radmin == false)
                {
                    phrase2 = "[IP HIDDEN]"; // HAHAHA DUDE THESE DOXXERS AND DDOSSERS ARE SO FUCKING FUNNY THEY MAKE ME WANT TO MERGE WITHOUT LOOKING!!!! 
                }

                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = "Playing a Game",
                    State = "on " + phrase2 + ":" + serverport.Text,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = "ingame",
                        SmallImageKey = "archblox",
                    }
                }); ;
                MessageBox.Show("Joining " + serverip.Text + ":" + serverport.Text, "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ask user to open dialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose a RBXL...";
            dialog.AddExtension = true;
            dialog.Filter = "ROBLOX Place File (*.rbxl)| *.rbxl";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                // check if it is a rbxl
                string word = Path.GetExtension(dialog.FileName);
                word = word.ToLower();
                if (word == ".rbxl")
                {
                    // Thanks to ROBLOX LEGACY PLACE CONVERTER by BakonBot for the binary rbxl format detection.
                    string[] file = System.IO.File.ReadAllLines(dialog.FileName);
                    foreach (var line in file)
                    {
                        if (line.Contains("<roblox!"))
                        {
                            // is binary/unsupported format
                            MessageBox.Show("Binary ROBLOX Place files are not supported. Did you convert the place correctly, or use ARCHBLOX Studio to create the game?", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            // it's supported, yay!
                            string destFile = Path.Combine(clientPath, @"Content\", Path.GetFileName(dialog.FileName));
                            System.IO.File.Copy(dialog.FileName, destFile, true);
                            textBox2.Text = Path.GetFileName(dialog.FileName);
                            return;
                        }
                    }
                }
                else if (word == ".rbxlx")
                {
                    // rbxlx, cringe!
                    MessageBox.Show(".RBXLX place files are not supported! Are you sure you converted the place correctly?", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // wtf this isn't even a place
                    MessageBox.Show(word.ToUpper() + " is not a supported place file!", "ARCHBLOX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void JoinBTN_Click(object sender, EventArgs e)
        {
            JoinBTN.Visible = false;
            HostBTN.Visible = false;
            UpdateBTN.Visible = false;
            JoinBox.Visible = true;
            HostBox.Visible = false;
            BackBTN.Visible = true;
        }

        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            ARCHBLOXLauncherGUI.Form2 form2 = new ARCHBLOXLauncherGUI.Form2();
            try
            {
                form2.Show();
            }
            catch
            {
                form2.Dispose();
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            JoinBTN.Visible = true;
            HostBTN.Visible = true;
            UpdateBTN.Visible = true;
            JoinBox.Visible = false;
            HostBox.Visible = false;
            BackBTN.Visible = false;
        }

        private void HostBTN_Click(object sender, EventArgs e)
        {
            JoinBTN.Visible = false;
            HostBTN.Visible = false;
            UpdateBTN.Visible = false;
            JoinBox.Visible = false;
            HostBox.Visible = true;
            BackBTN.Visible = true;
        }
    }
}