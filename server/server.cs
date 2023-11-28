using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    class Server
    {
        public static void StartServer()
        {

            //Listening IP address. Loopback is localhost
            IPAddress ipAddr = IPAddress.Loopback;

            // Port to listen on
            int port = 8081;

            // Create and start a listener for client connections
            TcpListener listener = new(ipAddr, port);
            listener.Start();
            
            // keep running
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                // Read the first byte representing the client command
                byte command = (byte)stream.ReadByte();

                if (command == 3)
                {
                    //list all files
                    string[] files = ListFiles();

                    // Convert an array of filenames to a string, separating each filename with "\n"
                    string fileList = string.Join("\n", files);

                    // Send file list to cache
                    StreamWriter writer = new(stream);
                    writer.Write(fileList);
                    writer.Flush();
                }
                else if (command == 1)
                {
                    // Receive filename length
                    byte[] data = new byte[4];
                    stream.Read(data, 0, 4);
                    int fileNameLength = BitConverter.ToInt32(data, 0);
                    // Receive file name
                    byte[] fileNameBytes = new byte[fileNameLength];
                    stream.Read(fileNameBytes, 0, fileNameLength);
                    string fileName = Encoding.UTF8.GetString(fileNameBytes);

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "../../../data");
                    string fileNamePath = Path.Combine(path, fileName);
                    StreamWriter writer = new StreamWriter(stream);
                    // read the contents of the file and send them to the client
                    using (StreamReader reader = new StreamReader(fileNamePath))
                    {
                        string fileContent = reader.ReadToEnd();
                        writer.WriteLine(fileContent);
                        
                    }
                    writer.Flush();
                }
                client.Close();
            }
        }
        //list file list function
        public static string[] ListFiles()
        {
            string fileDir = Path.Combine(Directory.GetCurrentDirectory(), "../../../data");
            string[] fileNames = Directory.GetFiles(fileDir);
            string[] fileNamesOnly = new string[fileNames.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNamesOnly[i] = Path.GetFileName(fileNames[i]);
            }
            return fileNamesOnly;
        }
        //add file function
        public static void AddFile(string filePath)
        {
            string fileDir = Path.Combine(Directory.GetCurrentDirectory(), "../../../data");
            string fileName = Path.GetFileName(filePath);

            // Copy the file into the service directory
            File.Copy(filePath, Path.Combine(fileDir, fileName), true);
        }
    }
}
