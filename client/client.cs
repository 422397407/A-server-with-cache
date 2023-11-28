using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    public class Client
    {
        //显示文件列表
        public static void ListFilesOnServer()
        {
            // Connect to the server
            TcpClient client = new("localhost", 8081);

            // Send command for listing files (0 for list)
            byte[] command = BitConverter.GetBytes(0);
            client.GetStream().Write(command, 0, command.Length);

            // Receive the list of files from the server
            byte[] buffer = new byte[1024];
            int bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);

            // Decode the list of files and display to the user
            string fileList = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Available files on the server: \n" + fileList);

            // Close the connection
            client.Close();
        }

        //选择下载文件
        public static void DownloadFile(string fileName)
        {
            // Connect to the server
            TcpClient client = new("localhost", 8081);

            // Send command for downloading file (1 for download)
            byte[] command = BitConverter.GetBytes(1);
            client.GetStream().Write(command, 0, command.Length);

            // Send the filename to the server
            byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);
            client.GetStream().Write(fileNameBytes, 0, fileNameBytes.Length);

            // Receive the file data from the server
            byte[] buffer = new byte[1024];
            int bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);

            // Write the file data to disk
            FileStream fileStream = new(fileName, FileMode.Create);
            while (bytesRead > 0)
            {
                fileStream.Write(buffer, 0, bytesRead);
                bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);
            }

            // Close the file and the connection
            fileStream.Close();
            client.Close();
        }

        //显示下载内容
        public static void DisplayFileContents(string fileName)
        {
            // Open the downloaded file
            StreamReader fileReader = new(fileName);

            // Read and display the contents of the file
            Console.WriteLine("Contents of downloaded file:");
            Console.WriteLine(fileReader.ReadToEnd());

            // Close the file
            fileReader.Close();
        }


    }

}