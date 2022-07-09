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
            Console.Clear();
            byte[] raw = wc.DownloadData("https://archblox.com/client/version.txt");
            string webData = Encoding.UTF8.GetString(raw);
            string version_string = webData;
            string folderPath = Path.Combine(@"C:\ARCHBLOX\", version_string + @"\");
            string filePath = Path.Combine(folderPath, "ArchbloxPlayerBeta.exe");
            Console.WriteLine("ARCHBLOX");
            Console.WriteLine("1) Join a Game");
            Console.WriteLine("2) Host a Game");
            string number = Console.ReadLine();
            if (number == "1")
            {
                Console.Clear();
                Console.WriteLine("Server IP:");
                string ip = Console.ReadLine();
                Console.WriteLine("Server Port:");
                string port = Console.ReadLine();
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("User ID:");
                string userid = Console.ReadLine();
                Console.WriteLine("Membership: (None BuildersClub TurboBuildersClub OutrageousBuildersClub)");
                string membership = Console.ReadLine();
                using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
                {
                    pProcess.StartInfo.FileName = filePath;
                    pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/join.php?port=" + port + "&app=" + userid + "&ip=" + ip + "&username=" + username + "&id=" + userid + "&membership=" + membership + "\" -t \"1\""; 
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    pProcess.StartInfo.CreateNoWindow = false;
                    pProcess.Start();
                    Main();
                }
            }
            else if (number == "2")
            {
                Console.Clear();
                Console.WriteLine("Server Port:");
                string port = Console.ReadLine();
                using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
                {
                    pProcess.StartInfo.FileName = filePath;
                    pProcess.StartInfo.Arguments = "-a \"http://www.morblox.us/\" -j \"http://www.morblox.us/game/gameserver.php?port=" + port + "\" -t \"1\"";
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    pProcess.StartInfo.CreateNoWindow = false;
                    pProcess.Start();
                    Main();
                }
            } else
            {
                Main();
            }
        }
    }
}
