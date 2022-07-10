using System;
using System.Net;
using System.Text;
using System.IO;
namespace ConsoleApp1
{
    internal class Program
    {
        private static WebClient wc = new WebClient();
        static void Main()
        {
            byte[] raw = wc.DownloadData("https://archblox.com/client/version.txt");
            string webData = Encoding.UTF8.GetString(raw);
            string version_string = webData;
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Archblx\", @"Versions\");
            string clientPath = Path.Combine(folderPath, version_string + @"\");
            string filePath = Path.Combine(clientPath, "ArchbloxPlayerBeta.exe");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine(" █████  ██████   ██████ ██   ██ ██████  ██       ██████  ██   ██ \n██   ██ ██   ██ ██      ██   ██ ██   ██ ██      ██    ██  ██ ██  \n███████ ██████  ██      ███████ ██████  ██      ██    ██   ███   \n██   ██ ██   ██ ██      ██   ██ ██   ██ ██      ██    ██  ██ ██  \n██   ██ ██   ██  ██████ ██   ██ ██████  ███████  ██████  ██   ██");
            Console.WriteLine("Type 1 to Join a Game or Type 2 to Host a Game");
            string number = Console.ReadLine();
            if (number == "1")
            {
                Console.Clear();
                Console.WriteLine("Server IP (Type \"localhost\" if joining your own server)");
                string ip = Console.ReadLine();
                Console.WriteLine("Server Port:");
                string port = Console.ReadLine();
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("User ID:");
                string userid = Console.ReadLine();
                // Console.WriteLine("Membership: (None BuildersClub TurboBuildersClub OutrageousBuildersClub)");
                // string membership = Console.ReadLine();
                string membership = "None";
                using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
                {
                    pProcess.StartInfo.FileName = filePath;
                    pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/join.php?port=" + port + "&app=" + userid + "&ip=" + ip + "&username=" + username + "&id=" + userid + "&membership=" + membership + "\" -t \"1\""; 
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    pProcess.StartInfo.CreateNoWindow = false;
                    pProcess.Start();
                    Console.WriteLine("Joining game server on " + ip + ":" + port + " as " + username + "(id: " + userid + ")");
                    Main();
                }
            }
            else if (number == "2")
            {
                Console.Clear();
                Console.WriteLine("Server Port (Default is 53640):");
                string port = Console.ReadLine();
                Console.WriteLine("RBXL Filename (use temp.rbxl if unsure, put .rbxl(s) in the content folder):");
                string filename = Console.ReadLine();
                using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
                {
                    pProcess.StartInfo.FileName = filePath;
                    pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/gameserver.php?port=" + port + "&rbxl=" + filename + "\" -t \"1\"";
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    pProcess.StartInfo.CreateNoWindow = false;
                    pProcess.Start();
                    Console.WriteLine("Launced game server on port " + port + ". You will have to port-forward that port or use tools such as Hamachi or RAdminVPN to let other users join the game.");
                    Main();
                }
            } else
            {
                Console.WriteLine(number + " is not a correct input!");
                Main();
            }
        }
    }
}
