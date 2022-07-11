using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using DiscordRPC;
using DiscordRPC.Logging;
namespace ARCHBLOXLauncher1
{
    public partial class Form1 : Form
    {
        bool lockanims = true;
        private DiscordRpcClient client;
        bool ingame = false;
        bool hosting = false;
        private static WebClient wc = new WebClient();
        static byte[] raw = wc.DownloadData("https://archblox.com/client/version.txt");
        static string webData = Encoding.UTF8.GetString(raw);
        static string version_string = webData;
        static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Archblx\", @"Versions\");
        static string clientPath = Path.Combine(folderPath, version_string + @"\");
        static string filePath = Path.Combine(clientPath, "ArchbloxPlayerBeta.exe");

        void slideOutJoinBox(object sender, EventArgs e)
        {
            lockanims = true;
            int x = JoinBox.Location.X;
            JoinBox.Location = new Point(x + 10, JoinBox.Location.Y);

            if (x > 358)
            {
                lockanims = false;
                AnimationHandler_SlideOutJoinBox.Stop();
            }
        }
        void slideInJoinBox(object sender, EventArgs e)
        {
            lockanims = true;
            int x = JoinBox.Location.X;
            JoinBox.Location = new Point(x - 10, JoinBox.Location.Y);

            if (x < 30)
            {
                lockanims = false;
                AnimationHandler_SlideInJoinBox.Stop();
            }
        }
        void slideOutHostBox(object sender, EventArgs e)
        {
            lockanims = true;
            int x = HostBox.Location.X;
            HostBox.Location = new Point(x + 10, HostBox.Location.Y);

            if (x > 358)
            {
                lockanims = false;
                AnimationHandler_SlideOutHostBox.Stop();
            }
        }
        void slideInHostBox(object sender, EventArgs e)
        {
            lockanims = true;
            int x = HostBox.Location.X;
            HostBox.Location = new Point(x - 10, HostBox.Location.Y);
            if (x < 30)
            {
                lockanims = false;
                AnimationHandler_SlideInHostBox.Stop();
            }
        }
        void slideOutBackBTNJoin(object sender, EventArgs e)
        {
            int y = BackBTN_Join.Location.Y;
            BackBTN_Join.Location = new Point(BackBTN_Join.Location.X, y - 8);

            if (y < -25)
            {
                AnimationHandler_SlideOutBackBTNJoin.Stop();
            }
        }
        void slideInBackBTNJoin(object sender, EventArgs e)
        {
            int y = BackBTN_Join.Location.Y;
            BackBTN_Join.Location = new Point(BackBTN_Join.Location.X, y + 8);

            if (y > 10)
            {
                AnimationHandler_SlideInBackBTNJoin.Stop();
            }
        }
        void slideOutBackBTNHost(object sender, EventArgs e)
        {
            int y = BackBTN_Host.Location.Y;
            BackBTN_Host.Location = new Point(BackBTN_Host.Location.X, y - 8);

            if (y < -25)
            {
                AnimationHandler_SlideOutBackBTNHost.Stop();
            }
        }
        void slideInBackBTNHost(object sender, EventArgs e)
        {
            int y = BackBTN_Host.Location.Y;
            BackBTN_Host.Location = new Point(BackBTN_Host.Location.X, y + 8);

            if (y > 10)
            {
                AnimationHandler_SlideInBackBTNHost.Stop();
            }
        }
        void slideInButtons(object sender, EventArgs e)
        {
            lockanims = true;
            UpdateBTN.Location = new Point(UpdateBTN.Location.X + 8, UpdateBTN.Location.Y);
            JoinBTN.Location = new Point(UpdateBTN.Location.X, JoinBTN.Location.Y);
            HostBTN.Location = new Point(UpdateBTN.Location.X, HostBTN.Location.Y);
            if (UpdateBTN.Location.X > 10)
            {
                AnimationHandler_SlideInButtons.Stop();
                lockanims = false;
            }
        }
        void slideOutButtons(object sender, EventArgs e)
        {
            lockanims = true;
            UpdateBTN.Location = new Point(UpdateBTN.Location.X - 8, UpdateBTN.Location.Y);
            JoinBTN.Location = new Point(UpdateBTN.Location.X, JoinBTN.Location.Y);
            HostBTN.Location = new Point(UpdateBTN.Location.X, HostBTN.Location.Y);
            if (UpdateBTN.Location.X < -278)
            {
                lockanims = false;
                AnimationHandler_SlideOutButtons.Stop();
            }
        }
        public Form1()
        {
            InitializeComponent();

            AnimationHandler_SlideOutHostBox.Tick += new EventHandler(slideOutHostBox);
            AnimationHandler_SlideInHostBox.Tick += new EventHandler(slideInHostBox);

            AnimationHandler_SlideOutJoinBox.Tick += new EventHandler(slideOutJoinBox);
            AnimationHandler_SlideInJoinBox.Tick += new EventHandler(slideInJoinBox);

            AnimationHandler_SlideOutBackBTNHost.Tick += new EventHandler(slideOutBackBTNHost);
            AnimationHandler_SlideInBackBTNHost.Tick += new EventHandler(slideInBackBTNHost);

            AnimationHandler_SlideOutBackBTNJoin.Tick += new EventHandler(slideOutBackBTNJoin);
            AnimationHandler_SlideInBackBTNJoin.Tick += new EventHandler(slideInBackBTNJoin);

            AnimationHandler_SlideOutButtons.Tick += new EventHandler(slideOutButtons);
            AnimationHandler_SlideInButtons.Tick += new EventHandler(slideInButtons);

            AnimationHandler_SlideInButtons.Start();

            client = new DiscordRpcClient("996030605106090006");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
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
            if (!File.Exists(filePath))
            {
                DialogResult res = MessageBox.Show("You need to install the latest version of ARCHBLOX to host. Would you like to install it?", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    ARCHBLOXLauncher1.Form2 form2 = new ARCHBLOXLauncher1.Form2();
                    form2.Show();
                }
            }
            else
            {
                void ProcessExitHandler(object sender, EventArgs args)
                {
                    hosting = false;
                    if (ingame == true)
                    {
                        client.SetPresence(new DiscordRPC.RichPresence()
                        {
                            Details = "Playing a Game",
                            State = "on " + serverip.Text + ":" + serverport.Text,
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
                MessageBox.Show("Starting game server on port " + textBox1.Text + " using " + textBox2.Text, "ARCHBLOX");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                DialogResult res = MessageBox.Show("You need to install the latest version of ARCHBLOX to join " + serverip.Text + ":" + serverport.Text + ". Would you like to install it?", "ARCHBLOX", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    ARCHBLOXLauncher1.Form2 form2 = new ARCHBLOXLauncher1.Form2();
                    form2.Show();
                }
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
                pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/join.php?port=" + serverport.Text + "&app=" + userid.Text + "&ip=" + serverip.Text + "&username=" + username.Text + "&id=" + userid.Text + "&membership=None\" -t \"1\"";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                pProcess.StartInfo.CreateNoWindow = false;
                pProcess.Start();
                pProcess.EnableRaisingEvents = true;
                pProcess.Exited += new EventHandler(ProcessExitHandler);
                client.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = "Playing a Game",
                    State = "on " + serverip.Text + ":" + serverport.Text,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = "ingame",
                        SmallImageKey = "archblox",
                    }
                }); ;
                MessageBox.Show("Joining IP " + serverip.Text + ":" + serverport.Text + " as " + username.Text + " (id: " + userid.Text + ")", "ARCHBLOX");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose a RBXL...";
            dialog.AddExtension = true;
            dialog.Filter = "Place File (*.rbxl)| *.rbxl";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                string destFile = Path.Combine(clientPath, @"Content\", Path.GetFileName(dialog.FileName));
                File.Copy(dialog.FileName, destFile, true);
                textBox2.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Form1_HelpButtonClicked(Object sender, CancelEventArgs e)
        {
            ARCHBLOXLauncher1.Form2 form2 = new ARCHBLOXLauncher1.Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void JoinBTN_Click(object sender, EventArgs e)
        {
            if (lockanims == false)
            {
                AnimationHandler_SlideOutButtons.Start();
                AnimationHandler_SlideInJoinBox.Start();
                AnimationHandler_SlideInBackBTNJoin.Start();
            }
        }

        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            ARCHBLOXLauncher1.Form2 form2 = new ARCHBLOXLauncher1.Form2();
            form2.Show();
        }

        private void BackBTN_Join_Click(object sender, EventArgs e)
        {
            if (lockanims == false) {
                AnimationHandler_SlideInButtons.Start();
                AnimationHandler_SlideOutJoinBox.Start();
                AnimationHandler_SlideOutBackBTNJoin.Start();
            }
        }

        private void BackBTN_Host_Click(object sender, EventArgs e)
        {
            if (lockanims == false)
            {
                AnimationHandler_SlideInButtons.Start();
                AnimationHandler_SlideOutHostBox.Start();
                AnimationHandler_SlideOutBackBTNHost.Start();
            }
        }

        private void HostBTN_Click(object sender, EventArgs e)
        {
            if (lockanims == false)
            {
                AnimationHandler_SlideOutButtons.Start();
                AnimationHandler_SlideInHostBox.Start();
                AnimationHandler_SlideInBackBTNHost.Start();
            }
        }
    }
}